using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Expert_Method_Preference : Form
    {
        private bool change = false; // Флаг изменений в ячейке оценок
        private bool error_range = false; // Флаг ошибки выхода за границы оценок

        public Expert_Method_Preference()
        {
            InitializeComponent();
        }

        // Закрытие окна
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
        private async void Expert_Method_Preference_Load(object sender, EventArgs e)
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
            labelInfo.Text = "*Расположите оценки в пределах от 1 до " + dataGridViewAlternatives.RowCount.ToString();

            // Получаем id проблемы
            // Получаем id эксперта
            int IdProblem = 001, IdExpert = 001;
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName = N'" + Data.selectedProblem.ToString() + "';", connection);
                    IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                    SqlCommand command2 = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                    IdExpert = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            FileInfo fileInfo = new FileInfo(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt");
            if (fileInfo.Exists) // Если файл существует, значит по этой проблеме какой то эксперт уже проводил оценивание
            {
                // Находим старую строку-оценивание
                Dictionary<int, List<string>> estimates = new Dictionary<int, List<string>>(); // Словарь, где ключ - IdExpert, а значение - оценки
                var lines = File.ReadAllLines(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt").ToList();
                foreach (string s in lines) // Строка из файла
                {
                    String[] elements = Regex.Split(s, " ");
                    estimates.Add(Convert.ToInt16(elements[0]), new List<string>());
                    for (int i = 1; i < elements.Length; i++) // Строку превращаем в словарь
                        estimates[Convert.ToInt16(elements[0])].Add(elements[i]);
                }
                if (estimates.ContainsKey(IdExpert)) // Если наш эксперт уже оценивал текущую проблему
                {
                    // Добавляем в таблицу старые значения оценок
                    foreach (KeyValuePair<int, List<string>> keyValue in estimates)
                    {
                        for (int i = 0; i < keyValue.Value.Count; i++)
                            dataGridViewAlternatives.Rows[i].Cells[1].Value = keyValue.Value[i];
                    }
                }
            }

            // Перемещение фокуса на первую ячейку оценок
            dataGridViewAlternatives.Focus();
            dataGridViewAlternatives.CurrentCell = dataGridViewAlternatives[1, 0];
        }

        // После окончания редактирования
        private void dataGridViewAlternatives_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            change = true; // Изменения в ячейке
            // Если введенное значение не попадает в интервал [1; кол-во альтернатив]
            if (Convert.ToInt16(dataGridViewAlternatives.CurrentCell.Value) > dataGridViewAlternatives.RowCount || Convert.ToInt16(dataGridViewAlternatives.CurrentCell.Value) < 1)
            {
                error_range = true;
                dataGridViewAlternatives.CurrentCell.Style.BackColor = Color.Tomato;
            }
            else
            {
                error_range = false;
                dataGridViewAlternatives.CurrentCell.Style.BackColor = Color.White;
            }
        }

        // Запрет на ввод любых символов, кроме цифр в столбец Оценка
        private void dataGridViewAlternatives_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
        }
        private void Cell_KeyPress(object Sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        // Проверка на дубликаты в столбце оценок
        private bool IsDuplicate()
        {
            bool isDuplicate = false;

            for (int row = 0; row < dataGridViewAlternatives.Rows.Count - 1; row++)
            {
                for (int elem = row + 1; elem < dataGridViewAlternatives.Rows.Count; elem++)
                {
                    if (Convert.ToInt16(dataGridViewAlternatives[1, row].Value) == Convert.ToInt16(dataGridViewAlternatives­[1, elem].Value))
                    {
                        isDuplicate = true;
                        dataGridViewAlternatives[1, row].Style.BackColor = dataGridViewAlternatives­[1, elem].Style.BackColor = Color.Tomato;
                        break;
                    }
                    else
                        dataGridViewAlternatives[1, row].Style.BackColor = dataGridViewAlternatives­[1, elem].Style.BackColor = Color.White;
                }
            }
            return isDuplicate;
        }

        // Завершить и сохранить результаты
        private async void buttonSaveTest_Click(object sender, EventArgs e)
        {
            // Проверка на пустоту столбца Оценок
            bool error = false;
            foreach (DataGridViewRow row in dataGridViewAlternatives.Rows)
            {
                if (row.Cells[1].Value == null)
                    error = true;
            }

            if (error) // Если есть пустые строки
            {
                labelError.Text = "Необходимо заполнить оценки для каждой альтернативы!";
                labelError.Visible = true; // Выводим ошибку
            }
            else // Если пустых строк нет
            {
                labelError.Visible = false;
                if (error_range) // Если эксперт ввел оценку меньше 1 или больше кол-ва альтернатив
                {
                    labelError.Text = "Оценка не может быть меньше 1 или превышать " + dataGridViewAlternatives.RowCount.ToString() + "!";
                    labelError.Visible = true;
                }
                else // Если оценки верные
                {
                    if (IsDuplicate()) // Если есть дубликаты
                    {
                        labelError.Text = "Для разных альтернатив нельзя задать одинаковые оценки!";
                        labelError.Visible = true;
                    }
                    else // Если дубликатов нет и эксперт все верно заполнил
                    {
                        labelError.Visible = false;

                        // Получаем id проблемы, чтобы создать файл (либо записать результаты в уже имеющийся)
                        // Получаем id эксперта для записи в строку
                        int IdProblem = 001, IdExpert = 001;
                        using (SqlConnection connection = new SqlConnection(Data.connectionString))
                        {
                            try
                            {
                                await connection.OpenAsync();
                                SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName = N'" + Data.selectedProblem.ToString() + "';", connection);
                                IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                                SqlCommand command2 = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                                IdExpert = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                                // Ставим статус true, то есть тест полностью завершен
                                SqlCommand command3 = new SqlCommand("Update ExpertProblems SET StatusTest3=1 where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString(), connection);
                                command3.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        FileInfo fileInfo = new FileInfo(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt");
                        if (fileInfo.Exists) // Если файл существует, значит по этой проблеме какой то эксперт уже проводил оценивание
                        {
                            // Находим старую строку-оценивание
                            Dictionary<int, List<string>> estimates = new Dictionary<int, List<string>>(); // Словарь, где ключ - IdExpert, а значение - оценки
                            var lines = File.ReadAllLines(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt").ToList();
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
                            using (StreamWriter sw = new StreamWriter("Data/MethodPreference/" + IdProblem.ToString() + ".txt", false, System.Text.Encoding.Default))
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
                                for (int i = 0; i < dataGridViewAlternatives.Rows.Count; i++)
                                {
                                    sw.Write(dataGridViewAlternatives.Rows[i].Cells[1].Value.ToString());
                                    if (i != dataGridViewAlternatives.Rows.Count - 1)
                                        sw.Write(" ");
                                }
                                sw.Close();
                            }
                            Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                            form.Activate();
                            Close();
                        }
                        else // Если файла (проблемы) нет, то нужно просто создать и записать в него
                        {
                            using (StreamWriter sw = new StreamWriter("Data/MethodPreference/" + IdProblem.ToString() + ".txt"))
                            {
                                sw.Write(IdExpert.ToString() + " ");
                                for (int i = 0; i < dataGridViewAlternatives.Rows.Count; i++)
                                {
                                    sw.Write(dataGridViewAlternatives.Rows[i].Cells[1].Value.ToString());
                                    if (i != dataGridViewAlternatives.Rows.Count - 1)
                                        sw.Write(" ");
                                }
                                sw.WriteLine();
                                sw.Close();
                            }
                            Form form = Application.OpenForms["ExpertMenu"]; // Вызываем форму меню эксперта
                            form.Activate();
                            Close();
                        }
                    }
                }
            }
        }
    }
}
