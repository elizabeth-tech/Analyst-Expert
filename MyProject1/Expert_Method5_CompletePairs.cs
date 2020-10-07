using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Expert_Method5_CompletePairs : Form
    {
        private Dictionary<int, List<string>> combinations = new Dictionary<int, List<string>>(); // Структура для комбинаций альтернатив
        private bool change = false; // Флаг изменений ячейки оценок

        public Expert_Method5_CompletePairs()
        {
            InitializeComponent();
        }

        // Рекурсивная функция факториала числа
        private int Fact(int num)
        {
            return (num > 1) ? num * Fact(num - 1) : 1;
        }

        // Реализация сочетаний
        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items) // item - объекты, которые перебираются, items - объект перечислений
            {
                if (count == 1) // Count - количество объектов в сочетании
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }
                ++i;
            }
        }

        // Закрыть окно
        private void buttonExpertLoginClose_Click(object sender, EventArgs e)
        {
            if (!change) // Если изменений в ячейке нет
            {
                Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                form.Activate();
                Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Все несохраненные изменения будут потеряны!\nВы уверены, что хотите закрыть оценивание?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }
                else
                    this.Activate();
            }
        }

        // Свернуть окно
        private void buttonExpertLoginTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Загрузка формы
        private async void Expert_Method_CompletePairs_Load(object sender, EventArgs e)
        {
            textBoxProblem.Text = Data.selectedProblem; // Выводим название проблемы, по которой проходим тест

            // Заполнение таблицы альтернативами выбранной проблемы
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("select Alternatives.AlternativeName" +
                        " from Problems" +
                        " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                        " where Problems.Id = (select Problems.Id from Problems" +
                        " where Problems.ProblemName = N'" + textBoxProblem.Text + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewAlternatives.Rows.Clear();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewAlternatives.Rows.Add();
                            dataGridViewAlternatives.Rows[i].Cells[0].Value = reader.GetString(0);
                            i++;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Формула числа сочетаний, определяющая количество вопросов в тесте
            int QuestionLength = Fact(dataGridViewAlternatives.RowCount) / (Fact(dataGridViewAlternatives.RowCount - 2) * 2);
            labelQuestionsCount.Text = "Сравнений на оценку: " + QuestionLength.ToString();
            labelCountAlter.Text = "Размерность шкалы: " + dataGridViewAlternatives.RowCount.ToString();

            // Реализация сочетаний альтернатив
            // Создаем структуру, ключ-значение. Где ключ - номер вопроса, а значение - две сравниваемые альтернативы
            var list = new List<string>();
            for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                list.Add(dataGridViewAlternatives.Rows[i].Cells[0].Value.ToString());
            List<string> alternatives = new List<string>();
            foreach (var number in GetPermutations(list, 2))
            {
                foreach (var n in number)
                    alternatives.Add(n);
            }
            int k = 0, c = 1;
            for (int i = 1; i < QuestionLength + 1; i++)
            {
                combinations.Add(i, new List<string> { alternatives[k], alternatives[c] });
                k += 2;
                c += 2;
            }

            // Заполнение таблицы оценивания данными
            for(int row = 0; row < combinations.Count; row++)
            {
                dataGridViewAssessment.Rows.Add();
                dataGridViewAssessment.Rows[row].Cells[0].Value = combinations[row + 1][0];
                dataGridViewAssessment.Rows[row].Cells[3].Value = combinations[row + 1][1];
            }

            /* Если данный тест был пройден ранее, то загружаем отметки оценок */
            // Получаем id эксперта и проблемы, чтобы найти данные
            int IdExpert = 001, IdProblem = 001;
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                    IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                    SqlCommand command2 = new SqlCommand("Select Id from Problems where ProblemName = N'" + Data.selectedProblem.ToString() + "';", connection);
                    IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Если нет папки, то значит эксперт никогда ранее не проходил этот тест и загружать данные не нужно
            string path = @"Data\MethodCompletePairs\" + IdExpert.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo fileInfo = new FileInfo(path + @"\" + IdProblem.ToString() + ".txt");
            if (dirInfo.Exists && fileInfo.Exists)// Если папка и файл есть, то загружаем оценки в столбцы    
            {
                using (StreamReader SR = new StreamReader(path + @"\" + IdProblem.ToString() + ".txt", Encoding.Default))
                {
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        string[] Columns = line.Split(' ');
                        dataGridViewAssessment.Rows[Convert.ToInt16(Columns[0])].Cells[1].Value = Columns[1];
                        dataGridViewAssessment.Rows[Convert.ToInt16(Columns[0])].Cells[2].Value = Columns[2];
                    }
                    SR.Close();
                }
            }

        }

        // Запрет на ввод любых символов, кроме цифр в столбец Оценок
        private void dataGridViewAssessment_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
        }
        private void Cell_KeyPress(object Sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        // Сохранить и отправить результаты
        private async void buttonSaveTest_Click(object sender, EventArgs e)
        {
            int countAlter = dataGridViewAlternatives.RowCount;
            // Формула числа сочетаний, определяющая количество вопросов в тесте
            int QuestionLength = Fact(countAlter) / (Fact(countAlter - 2) * 2);

            // Проверка на пустоту столбцов Оценок
            bool error = false;
            foreach (DataGridViewRow row in dataGridViewAssessment.Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    error = true;
                }
            }

            if (error) // Если есть пустые ячейки, значит эксперт не закончил тест
            {
                DialogResult result = MessageBox.Show("Вы не прошли тест до конца. Желаете закончить его позже?\n'Да' - Сохранить прогресс и выйти\n'Нет' - Выйти", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                {
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }
                else // Сохраняем прогресс эксперта в файл и выходим
                {
                    // Получаем id эксперта и проблемы, чтобы создать папку и файл (либо записать результаты в уже имеющуюся)
                    int IdExpert = 001, IdProblem = 001;
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                            IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                            SqlCommand command2 = new SqlCommand("Select Id from Problems where ProblemName = N'" + Data.selectedProblem.ToString() + "';", connection);
                            IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                            // Ставим статус 2, то есть тест еще не закончен
                            SqlCommand command3 = new SqlCommand("Update ExpertProblems SET StatusTest5=2 where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString(), connection);
                            command3.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    // Если нет папки, то создаем ее
                    DirectoryInfo dirInfo = new DirectoryInfo(@"Data\MethodCompletePairs\" + IdExpert.ToString());
                    if (!dirInfo.Exists)
                        dirInfo.Create();

                    // Записываем в файл номер строки таблицы и значения Оценок
                    using (StreamWriter sw = new StreamWriter("Data/MethodCompletePairs/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                    {
                        for (int i = 0; i < dataGridViewAssessment.RowCount; i++)
                        {
                            if (dataGridViewAssessment.Rows[i].Cells[1].Value != null && dataGridViewAssessment.Rows[i].Cells[2].Value != null)
                                sw.Write(i.ToString() + " " + dataGridViewAssessment.Rows[i].Cells[1].Value + " " + dataGridViewAssessment.Rows[i].Cells[2].Value + "\n");
                        }
                        sw.Close();
                    }
                    this.DialogResult = DialogResult.OK;
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }
            }
            else // Если пустых ячеек нет, то эксперт полностью прошел тест
            {

                // Заполняем матрицу нулями
                double[,] matrix = new double[countAlter, countAlter];
                for (int i = 0; i < countAlter; i++)
                {
                    for (int k = 0; k < countAlter; k++)
                        matrix[i, k] = 0;
                }

                // Заполняем значениями из столбцов Оценок
                int d = 0, t = 0;
                for (int i = 0; i < countAlter - 1; i++)
                {
                    d++;
                    for (int j = d; j < countAlter; j++)
                    {
                        matrix[i, j] = Convert.ToInt16(dataGridViewAssessment[1, t].Value);
                        matrix[j, i] = Convert.ToInt16(dataGridViewAssessment[2, t].Value);
                        t++;
                    }
                }

                // Получаем id эксперта и проблемы, чтобы создать папку и файл (либо записать результаты в уже имеющуюся)
                int IdExpert = 001, IdProblem = 001;
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                        IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        SqlCommand command2 = new SqlCommand("Select Id from Problems where ProblemName = N'" + Data.selectedProblem.ToString() + "';", connection);
                        IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        // Ставим статус 1, то есть тест полностью завершен
                        SqlCommand command3 = new SqlCommand("Update ExpertProblems SET StatusTest5=1 where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString(), connection);
                        command3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // Если нет папки, то создаем ее
                DirectoryInfo dirInfo = new DirectoryInfo(@"Data\MethodCompletePairs\" + IdExpert.ToString());
                if (!dirInfo.Exists)
                    dirInfo.Create();

                // Записываем в файл номер строки таблицы и значения Оценок
                using (StreamWriter sw = new StreamWriter("Data/MethodCompletePairs/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                {
                    for (int i = 0; i < dataGridViewAssessment.RowCount; i++)
                    {
                        if (dataGridViewAssessment.Rows[i].Cells[1].Value != null && dataGridViewAssessment.Rows[i].Cells[2].Value != null)
                            sw.Write(i.ToString() + " " + dataGridViewAssessment.Rows[i].Cells[1].Value + " " + dataGridViewAssessment.Rows[i].Cells[2].Value + "\n");
                    }
                    sw.Close();
                }

                // Метод полного попарного сравнения
                int N = countAlter * (countAlter - 1);

                // Суммирование оценок по соответствующей строке матрицы предпочтений
                double[] f = new double[countAlter];
                for (int i = 0; i < countAlter; i++)
                    for (int j = 0; j < countAlter; j++)
                        f[i] += matrix[i, j] / countAlter;

                // Находим g - нормированные оценки
                double[] g = new double[countAlter];
                for (int i = 0; i < countAlter; i++)
                    g[i] = f[i] / N;
   
                // Далее нужно сохранить строку нормированных оценок к остальным оценкам по этой проблеме (только от других экспертов)
                
                FileInfo fileInfo = new FileInfo(@"Data\Result5_MethodCompletePairs\" + IdProblem.ToString() + ".txt");
                if (fileInfo.Exists) // Если файл существует, значит по этой проблеме какой то эксперт уже проводил оценивание
                {
                    // Находим старую строку-оценивание
                    Dictionary<int, List<string>> estimates = new Dictionary<int, List<string>>(); // Словарь, где ключ - IdExpert, а значение - оценки
                    var lines = File.ReadAllLines(@"Data\Result5_MethodCompletePairs\" + IdProblem.ToString() + ".txt").ToList();
                    foreach (string s in lines) // Строка из файла
                    {
                        String[] elements = Regex.Split(s, " ");
                        estimates.Add(Convert.ToInt16(elements[0]), new List<string>());
                        for (int i = 1; i < elements.Length; i++) // Строку превращаем в словарь
                            estimates[Convert.ToInt16(elements[0])].Add(elements[i]);
                    }
                    if (estimates.ContainsKey(IdExpert)) // Если наш эксперт уже оценивал текущую проблему
                        estimates.Remove(IdExpert); // Удаляем старую строку

                    // Сохранение в файл старых данных (false - перезапись файла)
                    using (StreamWriter sw = new StreamWriter("Data/Result5_MethodCompletePairs/" + IdProblem.ToString() + ".txt", false, System.Text.Encoding.Default))
                    {
                        foreach (KeyValuePair<int, List<string>> keyValue in estimates)
                        {
                            sw.Write(keyValue.Key.ToString() + " ");
                            for (int i = 0; i < keyValue.Value.Count; i++)
                            {
                                sw.Write(keyValue.Value[i].ToString());
                                if (i != keyValue.Value.Count - 1)
                                    sw.Write(" ");
                            }
                            sw.WriteLine();
                        }
                        sw.Write(IdExpert.ToString() + " ");
                        // Дописываем новую (свежую) строку с оцениванием
                        for (int i = 0; i < countAlter; i++)
                        {
                            sw.Write(g[i].ToString());
                            if (i != countAlter - 1)
                                sw.Write(" ");
                        }
                        sw.Close();
                    }
                    this.DialogResult = DialogResult.OK;
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }
                else // Если файла (проблемы) нет, то нужно просто создать и записать в него
                {
                    using (StreamWriter sw = new StreamWriter("Data/Result5_MethodCompletePairs/" + IdProblem.ToString() + ".txt"))
                    {
                        sw.Write(IdExpert.ToString() + " ");
                        for (int i = 0; i < countAlter; i++)
                        {
                            sw.Write(g[i].ToString());
                            if (i != countAlter - 1)
                                sw.Write(" ");
                        }
                        sw.Close();
                    }
                    this.DialogResult = DialogResult.OK;
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }

            }

        }

        // После окончания редактирования
        private void dataGridViewAssessment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            change = true; // Изменения в ячейке
            // Если значение в редактируемой ячейке выходит за границы диапазона
            if (Convert.ToInt16(dataGridViewAssessment.CurrentCell.Value) > dataGridViewAlternatives.RowCount || Convert.ToInt16(dataGridViewAssessment.CurrentCell.Value) < 0)
                dataGridViewAssessment.CurrentCell.Style.BackColor = Color.Tomato;
            else // Рассчитываем значение во второй ячейке
            {
                dataGridViewAssessment.CurrentCell.Style.BackColor = Color.White;
                if (dataGridViewAssessment.CurrentCell.ColumnIndex == 1)
                    dataGridViewAssessment[dataGridViewAssessment.CurrentCell.ColumnIndex + 1, dataGridViewAssessment.CurrentCell.RowIndex].Value = dataGridViewAlternatives.RowCount - Convert.ToInt16(dataGridViewAssessment.CurrentCell.Value);
                else
                    dataGridViewAssessment[dataGridViewAssessment.CurrentCell.ColumnIndex - 1, dataGridViewAssessment.CurrentCell.RowIndex].Value = dataGridViewAlternatives.RowCount - Convert.ToInt16(dataGridViewAssessment.CurrentCell.Value);
            }
        }
    }
}
