using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertMenu : Form
    {
        private bool flag = false; // флаг наличия назначенных проблем у эксперта, true - если есть

        public ExpertMenu()
        {
            InitializeComponent();
        }

        // Закрытие окна с основным меню для эксперта
        private void buttonExpertProblemClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Сворачивание окна с основным меню эксперта
        private void buttonExpertProblemTurn_Click(object sender, EventArgs e)
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

        // Загрузка формы и заполнение comboBox проблемами
        private async void ExpertMenu_Load(object sender, EventArgs e)
        {
            label3.Text = Data.nameExpert.ToString(); // Вывод ФИО эксперта

            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Problems.ProblemName from ExpertProblems " +
                        "join Problems on Problems.Id = ExpertProblems.IdProblem " +
                        "where IdExpert = (Select Id from Experts where FIOExpert = N'" + label3.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        flag = true;
                        label7.Visible = false; // Убираем текст "Аналитик еще не назначил вам ни одной проблемы"
                        label2.Text = "Есть доступные тесты"; // Статус прохождения теста
                        label2.ForeColor = Color.Green;
                        comboBox1.Visible = true; // Вкладка с проблемами

                        // Красим кнопки Пройти в зеленый и открываем доступ
                        button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = true;
                        button2.BackColor = button3.BackColor = button4.BackColor = button5.BackColor = button6.BackColor = Color.FromArgb(224, 237, 218);

                        // Вносим проблемы
                        while (reader.Read())
                            comboBox1.Items.Add(reader.GetString(0));
                        comboBox1.Text = comboBox1.Items[0].ToString();      
                    }
                    else
                    {
                        flag = false;
                        label7.Visible = true; // Вывод текста "Аналитик еще не назначил вам ни одной проблемы"
                        label2.Text = "Нет доступных тестов"; // Статус прохождения теста
                        label2.ForeColor = Color.Red;
                        comboBox1.Visible = false; // Вкладка с проблемами

                        // Красим кнопки Пройти в красный и закрываем доступ
                        button2.BackColor = button3.BackColor = button4.BackColor = button5.BackColor = button6.BackColor = Color.DarkSalmon;
                        button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Открытие окна метода парных сравнений
        private void button2_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method1_PairwiseComparison f = new Expert_Method1_PairwiseComparison();
            f.ShowDialog();
        }

        // Определение статуса теста
        private async void StatusTests()
        {
            if (flag) // Чтобы изменять только при имеющихся проблемах
            {
                // Получаем id эксперта и проблемы, чтобы найти данные
                int IdExpert = 001, IdProblem = 001;
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                        IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        SqlCommand command2 = new SqlCommand("Select Id from Problems where ProblemName = N'" + comboBox1.Text + "';", connection);
                        IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // 1) Метод парных сравнений
                // Если есть папка эксперта и выбранная проблема, то значит тест ранее уже проходился этим экспертом
                /*string path = @"Data\MethodComparison\" + IdExpert.ToString();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                FileInfo fileInfo = new FileInfo(path + @"\" + IdProblem.ToString() + ".txt");
                if (dirInfo.Exists && fileInfo.Exists) // Если папка есть и есть файл проблемы*/
                // Проверяем статус теста
                int status = 0;
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select StatusTest1 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                        status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        // Красим кнопку Пройти в оранжевый и изменяем текст
                        button2.BackColor = Color.PeachPuff;
                        button2.Text = "Закончить оценивание";
                        checkBox1.Checked = false;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        // Красим кнопку Пройти в желтый и изменяем текст
                        button2.BackColor = Color.LemonChiffon;
                        button2.Text = "Изменить ответы";
                        checkBox1.Checked = true;

                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        // Красим кнопку Пройти в зеленый и изменяем текст
                        button2.BackColor = Color.FromArgb(224, 237, 218);
                        button2.Text = "Пройти";
                        checkBox1.Checked = false;
                    }
                }

                // 2) Метод взвешенных экспертных оценок
                // Если есть файл, то значит тест ранее уже проходился кем то
                // fileInfo = new FileInfo(@"Data\MethodWeightedAssessments\" + IdProblem.ToString() + ".txt");
                //if (fileInfo.Exists) // Если есть файл проблемы
                // Проверяем статус теста
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select StatusTest2 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                        status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (status == 0) // Эксперт не проходил тест по этой проблеме
                    {
                        // Красим кнопку Пройти в зеленый и изменяем текст
                        button3.BackColor = Color.FromArgb(224, 237, 218);
                        button3.Text = "Пройти";
                        checkBox2.Checked = false;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        // Красим кнопку Пройти в желтый и изменяем текст
                        button3.BackColor = Color.LemonChiffon;
                        button3.Text = "Изменить ответы";
                        checkBox2.Checked = true;
                    }
                }

                // 3) Метод предпочтения
                // Если есть файл, то значит тест ранее уже проходился кем то
                //fileInfo = new FileInfo(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt");
                //if (fileInfo.Exists) // Если есть файл проблемы
                // Проверяем статус теста
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select StatusTest3 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                        status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (status == 0) // Эксперт не проходил тест по этой проблеме
                    {
                        // Красим кнопку Пройти в зеленый и изменяем текст
                        button4.BackColor = Color.FromArgb(224, 237, 218);
                        button4.Text = "Пройти";
                        checkBox3.Checked = false;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        // Красим кнопку Пройти в желтый и изменяем текст
                        button4.BackColor = Color.LemonChiffon;
                        button4.Text = "Изменить ответы";
                        checkBox3.Checked = true;
                    }
                }

                // 4) Метод ранга
                // Если есть файл, то значит тест ранее уже проходился кем то
                //fileInfo = new FileInfo(@"Data\MethodRang\" + IdProblem.ToString() + ".txt");
                //if (fileInfo.Exists) // Если есть файл проблемы
                // Проверяем статус теста
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select StatusTest4 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                        status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (status == 0) // Эксперт не проходил тест по этой проблеме
                    {
                        // Красим кнопку Пройти в зеленый и изменяем текст
                        button5.BackColor = Color.FromArgb(224, 237, 218);
                        button5.Text = "Пройти";
                        checkBox4.Checked = false;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        // Красим кнопку Пройти в желтый и изменяем текст
                        button5.BackColor = Color.LemonChiffon;
                        button5.Text = "Изменить ответы";
                        checkBox4.Checked = true;
                    }
                }

                // 5) Метод полного попарного сравнения
                // Если есть файл, то значит тест ранее уже проходился кем то
                //path = @"Data\MethodCompletePairs\" + IdExpert.ToString();
                //dirInfo = new DirectoryInfo(path);
                //fileInfo = new FileInfo(path + @"\" + IdProblem.ToString() + ".txt");
                //if (dirInfo.Exists && fileInfo.Exists) // Если папка есть и есть файл проблемы
                // Проверяем статус теста
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select StatusTest5 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                        status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        // Красим кнопку Пройти в оранжевый и изменяем текст
                        button6.BackColor = Color.PeachPuff;
                        button6.Text = "Закончить оценивание";
                        checkBox5.Checked = false;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        // Красим кнопку Пройти в желтый и изменяем текст
                        button6.BackColor = Color.LemonChiffon;
                        button6.Text = "Изменить ответы";
                        checkBox5.Checked = true;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        // Красим кнопку Пройти в зеленый и изменяем текст
                        button6.BackColor = Color.FromArgb(224, 237, 218);
                        button6.Text = "Пройти";
                        checkBox5.Checked = false;
                    }
                }
            }
        }

        // При выборе другой проблемы
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusTests();
        }

        // При активации формы, обновляем состояние
        private void ExpertMenu_Activated(object sender, EventArgs e)
        {
            StatusTests();
        }

        // Открытие окна метода Взвешенных экспертных оценок
        private void button3_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method2_WeightedExpertAssessments f = new Expert_Method2_WeightedExpertAssessments();
            f.ShowDialog();
        }

        // Открытие окна метода Предпочтения
        private void button4_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method3_Preference f = new Expert_Method3_Preference();
            f.ShowDialog();
        }

        // Открытие окна метода Ранга
        private void button5_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method4_Rang f = new Expert_Method4_Rang();
            f.ShowDialog();
        }

        // Открытие окна метода полного попарного сравнения
        private void button6_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method5_CompletePairs f = new Expert_Method5_CompletePairs();
            f.ShowDialog();
        }
    }
}
