using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Expert_Method1_PairwiseComparison : Form
    {
        private Dictionary<int, List<string>> combinations = new Dictionary<int, List<string>>(); // Структура для комбинаций альтернатив
        private Dictionary<int, double> choices = new Dictionary<int, double>(); // Структура для хранения выбора radiobutton для каждого вопроса
        private bool flag = false; // флаг изменения ответов, true если были изменены

        public Expert_Method1_PairwiseComparison()
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

        // Закрытие окна
        private void buttonExpertLoginClose_Click(object sender, EventArgs e)
        {
            if (choices.Count < 1 || !flag) // Если изменения не были внесены (отметок radiobutton нет), то просто закрываем
            {
                Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                form.Activate();
                Close();
            }
            if(flag)
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

        // Сворачивание окна
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
        private async void Expert_Method_PairwiseComparison_Load(object sender, EventArgs e)
        {
            textBox2.Text = Data.selectedProblem; // Выводим название проблемы, по которой проходим тест
            buttonLeft.Visible = false;

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
                        " where Problems.ProblemName = N'" + textBox2.Text + "')", connection);
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
            for (int i = 1; i <= QuestionLength; i++) // Вносим номера вопросов в comboBox
                comboBox1.Items.Add(i);
            comboBox1.Text = comboBox1.Items[0].ToString();
            label6.Text = QuestionLength.ToString();

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

            /* Если данный тест был пройден ранее, то загружаем отметки radiobutton */
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
            string path = @"Data\MethodComparison\" + IdExpert.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo fileInfo = new FileInfo(path + @"\" + IdProblem.ToString() + ".txt");
            if (dirInfo.Exists && fileInfo.Exists)// Если папка и файл есть, то загружаем отметки в choices      
            {
                using (StreamReader SR = new StreamReader(path + @"\" + IdProblem.ToString() + ".txt", Encoding.Default))
                {
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        string[] Columns = line.Split(' ');
                        choices.Add(Convert.ToInt16(Columns[0]), Convert.ToDouble(Columns[1]));
                    }
                    SR.Close();
                }  
            }
            SelectRadioButton(); // Отображаем отметки в radiobutton
        }

        // Сохранение в память выбранных значений Radiobutton
        private void SelectRadioButton()
        {
            // Отображение альтернатив
            textBoxAlter1.Text = combinations[Convert.ToInt16(comboBox1.Text)][0];
            textBoxAlter2.Text = combinations[Convert.ToInt16(comboBox1.Text)][1];
            
            // Если пользователь уже выбирал ответ на этот вопрос
            if (choices.TryGetValue(comboBox1.SelectedIndex, out double value))
            {
                if (value == 1)
                    radioButton1.Checked = true;
                if (value == 0.5)
                    radioButton2.Checked = true;
                if (value == 0)
                    radioButton3.Checked = true;
            }
            else
                radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
        }

        // Переход на предыдущий вопрос
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            buttonRight.Visible = true;
            if (comboBox1.SelectedIndex >= 1)
            {
                int index = comboBox1.SelectedIndex - 1;
                comboBox1.SelectedIndex = index;
                SelectRadioButton();
            }
            // Если первый вопрос, то убираем стрелку влево
            if (comboBox1.SelectedIndex == 0)
                buttonLeft.Visible = false;
            else
                buttonLeft.Visible = true;
        }

        // Переход на следующий вопрос
        private void buttonRight_Click(object sender, EventArgs e)
        {
            buttonLeft.Visible = true;
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
            {
                int index = comboBox1.SelectedIndex + 1;
                comboBox1.SelectedIndex = index;
                SelectRadioButton();
            }
            // Если последний вопрос, то убираем стрелку вправо
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
                buttonRight.Visible = false;
            else
                buttonRight.Visible = true;
        }

        // При изменении номера вопроса, выводим нужное сочетание альтернатив
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Если первый вопрос, то убираем стрелку влево
            if (comboBox1.SelectedIndex == 0)
                buttonLeft.Visible = false;
            else
                buttonLeft.Visible = true;

            // Если последний вопрос, то убираем стрелку вправо
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
                buttonRight.Visible = false;
            else
                buttonRight.Visible = true;

            SelectRadioButton(); // Сохранение в память выбранных значений Radiobutton
        }

        // Сохранить и отправить результаты
        private async void buttonSaveTest_Click(object sender, EventArgs e)
        {
            int countAlter = dataGridViewAlternatives.RowCount;
            // Формула числа сочетаний, определяющая количество вопросов в тесте
            int QuestionLength = Fact(countAlter) / (Fact(countAlter - 2) * 2);

            if (choices.Count != QuestionLength) // Если эксперт оценил не все альтернативы
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
                            SqlCommand command3 = new SqlCommand("Update ExpertProblems SET StatusTest1=2 where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString(), connection);
                            command3.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    // Если нет папки, то создаем ее
                    DirectoryInfo dirInfo = new DirectoryInfo(@"Data\MethodComparison\" + IdExpert.ToString());
                    if (!dirInfo.Exists)
                        dirInfo.Create();

                    // Сохранение в файл данных об отметках radiobutton (чтобы загружать их) 
                    using (StreamWriter sw = new StreamWriter("Data/MethodComparison/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                    {
                        foreach (KeyValuePair<int, double> keyValue in choices)
                            sw.Write("{0} {1}\n", keyValue.Key.ToString(), keyValue.Value.ToString());
                        sw.Close();
                    }
                    Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                    form.Activate();
                    Close();
                }
            }
            // Если эксперт заполнил все ответы, то можно сохранить их в файл
            else
            {
                // Заполняем матрицу нулями
                double[,] matrix = new double[countAlter, countAlter];
                for (int i = 0; i < countAlter; i++)
                {
                    for (int k = 0; k < countAlter; k++)
                        matrix[i, k] = 0;
                }

                // Заполняем значениями из тестов
                int d = 0, t = 0;
                for (int i = 0; i < countAlter - 1; i++)
                {
                    d++;
                    for (int j = d; j < countAlter; j++)
                    {
                        matrix[i, j] = choices[t];
                        if (choices[t] == 0.5)
                            matrix[j, i] = 0.5;
                        if (choices[t] == 0)
                            matrix[j, i] = 1;
                        t++;
                    }
                }

                /* Алгоритм парных сравнений по матрице предпочтений */

                // Суммирование оценок по соответствующей строке матрицы предпочтений
                double[] C = new double[countAlter]; // Цена, которая обозначает важность каждой альтернативы
                for (int i = 0; i < countAlter; i++)
                    for (int j = 0; j < countAlter; j++)
                        C[i] += matrix[i, j];

                // Находим R - сумму всех цен
                double R = 0;
                for (int i = 0; i < countAlter; i++)
                    R += C[i];

                // Нормирование полученных цен
                double[] V = new double[countAlter];
                for (int i = 0; i < countAlter; i++)
                    V[i] = C[i] / R;

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
                        SqlCommand command3 = new SqlCommand("Update ExpertProblems SET StatusTest1=1 where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString(), connection);
                        command3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // Если нет папки, то создаем ее
                DirectoryInfo dirInfo = new DirectoryInfo(@"Data\Result1_MethodComparison\" + IdExpert.ToString());
                if (!dirInfo.Exists)
                    dirInfo.Create();

                // Вывод результата в файл где папка - id эксперта, а номер файла txt - номер проблемы 
                using (StreamWriter sw = new StreamWriter("Data/Result1_MethodComparison/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                {
                    for (int i = 0; i < countAlter; i++)
                        sw.Write("{0}\n", V[i]);
                    sw.Close();
                }

                // Если нет папки, то создаем ее
                DirectoryInfo dirInfo2 = new DirectoryInfo(@"Data\MethodComparison\" + IdExpert.ToString());
                if (!dirInfo2.Exists)
                    dirInfo2.Create();

                // Сохранение в файл данных об отметках radiobutton (чтобы загружать их) 
                using (StreamWriter sw = new StreamWriter("Data/MethodComparison/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                {
                    for (int i = 0; i < QuestionLength; i++)
                        sw.Write("{0} {1}\n", i, choices[i]);
                    sw.Close();
                }
                Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                form.Activate();
                Close();
            }
        }

        // Первый вариант
        private void radioButton1_Click(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton1.Checked == true)
            {
                flag = true;
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 1;
                else
                    choices.Add(comboBox1.SelectedIndex, 1);
            }
        }

        // Второй вариант
        private void radioButton2_Click(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton2.Checked == true)
            {
                flag = true;
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 0.5;
                else
                    choices.Add(comboBox1.SelectedIndex, 0.5);
            }
        }

        // Третий вариант
        private void radioButton3_Click(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton3.Checked == true)
            {
                flag = true;
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 0;   
                else
                    choices.Add(comboBox1.SelectedIndex, 0);
            }
        }
    }
}
