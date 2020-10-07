using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertMenu : Form
    {
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
            labelFIO.Text = Data.nameExpert.ToString(); // Вывод ФИО эксперта
            comboBoxTests.Text = comboBoxTests.Items[0].ToString(); // Выводим название теста

            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем список проблем
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Problems.ProblemName from ExpertProblems " +
                        "join Problems on Problems.Id = ExpertProblems.IdProblem " +
                        "where IdExpert = (Select Id from Experts where FIOExpert = N'" + labelFIO.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // Если для текущего эксперта есть назначенные проблемы
                    {
                        label7.Visible = false; // Убираем текст "Аналитик еще не назначил вам ни одной проблемы"
                        label2.Text = "Есть доступные тесты"; // Доступность теста
                        label2.ForeColor = Color.Green;
                        comboBoxProblems.Visible = true; // Вкладка с проблемами                      
                        buttonOk.Enabled = true; // Открываем доступ к кнопке Пройти
                        comboBoxTests.Enabled = true; // Открываем доступ к выбору метода

                        // Вносим проблемы
                        while (reader.Read())
                            comboBoxProblems.Items.Add(reader.GetString(0));
                        comboBoxProblems.Text = comboBoxProblems.Items[0].ToString();    

                        int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                        int status = StatusTests(index);

                        if (status == 2) // Эксперт проходил тест ранее, но не закончил
                        {
                            labelStatus.Text = "Не завершено";
                            labelStatus.ForeColor = Color.Red;
                        }
                        if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                        {
                            labelStatus.Text = "Завершено. Возможно изменение ответов";
                            labelStatus.ForeColor = Color.DarkCyan;
                        }
                        if (status == 0) // Оценивание еще не проводилось
                        {
                            labelStatus.Text = "Не проводилось";
                            labelStatus.ForeColor = Color.Black;
                        }
                    }
                    else // Если для текущего эксперта нет назначенных проблем
                    {
                        label7.Visible = true; // Вывод текста "Аналитик еще не назначил вам ни одной проблемы"
                        label2.Text = "Нет доступных тестов"; // Доступность теста
                        label2.ForeColor = Color.Red;
                        comboBoxProblems.Visible = false; // Вкладка с проблемами

                        buttonOk.Enabled = false; // Закрываем доступ к кнопке Пройти
                        comboBoxTests.Enabled = false; // Закрываем доступ к выбору метода
                        label8.Visible = false;
                        labelStatus.Visible = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Кнопка Открыть оценивание - Открытие выбранного оценивания (метода)
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(comboBoxTests.Text == "Парных сравнений")
            {
                Data.selectedProblem = comboBoxProblems.Text;
                Expert_Method1_PairwiseComparison f = new Expert_Method1_PairwiseComparison();
                if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна
                {
                    // Обновляем статус оценивания
                    int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                    int status = StatusTests(index);

                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        labelStatus.Text = "Не завершено";
                        labelStatus.ForeColor = Color.Red;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        labelStatus.Text = "Завершено. Возможно изменение ответов";
                        labelStatus.ForeColor = Color.DarkCyan;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        labelStatus.Text = "Не проводилось";
                        labelStatus.ForeColor = Color.Black;
                    }
                }
            }
            if(comboBoxTests.Text == "Взвешенных экспертных оценок")
            {
                Data.selectedProblem = comboBoxProblems.Text;
                Expert_Method2_WeightedExpertAssessments f = new Expert_Method2_WeightedExpertAssessments();
                if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна
                {
                    // Обновляем статус оценивания
                    int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                    int status = StatusTests(index);

                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        labelStatus.Text = "Не завершено";
                        labelStatus.ForeColor = Color.Red;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        labelStatus.Text = "Завершено. Возможно изменение ответов";
                        labelStatus.ForeColor = Color.DarkCyan;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        labelStatus.Text = "Не проводилось";
                        labelStatus.ForeColor = Color.Black;
                    }
                }
            }
            if (comboBoxTests.Text == "Предпочтения")
            {
                Data.selectedProblem = comboBoxProblems.Text;
                Expert_Method3_Preference f = new Expert_Method3_Preference();
                if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна
                {
                    // Обновляем статус оценивания
                    int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                    int status = StatusTests(index);

                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        labelStatus.Text = "Не завершено";
                        labelStatus.ForeColor = Color.Red;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        labelStatus.Text = "Завершено. Возможно изменение ответов";
                        labelStatus.ForeColor = Color.DarkCyan;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        labelStatus.Text = "Не проводилось";
                        labelStatus.ForeColor = Color.Black;
                    }
                }
            }
            if (comboBoxTests.Text == "Ранга")
            {
                Data.selectedProblem = comboBoxProblems.Text;
                Expert_Method4_Rang f = new Expert_Method4_Rang();
                if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна
                {
                    // Обновляем статус оценивания
                    int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                    int status = StatusTests(index);

                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        labelStatus.Text = "Не завершено";
                        labelStatus.ForeColor = Color.Red;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        labelStatus.Text = "Завершено. Возможно изменение ответов";
                        labelStatus.ForeColor = Color.DarkCyan;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        labelStatus.Text = "Не проводилось";
                        labelStatus.ForeColor = Color.Black;
                    }
                }
            }
            if (comboBoxTests.Text == "Полного попарного сравнения")
            {
                Data.selectedProblem = comboBoxProblems.Text;
                Expert_Method5_CompletePairs f = new Expert_Method5_CompletePairs();
                if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна
                {
                    // Обновляем статус оценивания
                    int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
                    int status = StatusTests(index);

                    if (status == 2) // Эксперт проходил тест ранее, но не закончил
                    {
                        labelStatus.Text = "Не завершено";
                        labelStatus.ForeColor = Color.Red;
                    }
                    if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
                    {
                        labelStatus.Text = "Завершено. Возможно изменение ответов";
                        labelStatus.ForeColor = Color.DarkCyan;
                    }
                    if (status == 0) // Оценивание еще не проводилось
                    {
                        labelStatus.Text = "Не проводилось";
                        labelStatus.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Определение статуса теста
        private int StatusTests(int indexTest)
        {
            // Получаем id эксперта и проблемы, чтобы найти данные
            int IdExpert = 001, IdProblem = 001;
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert = N'" + Data.nameExpert.ToString() + "';", connection);
                    IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                    command = new SqlCommand("Select Id from Problems where ProblemName = N'" + comboBoxProblems.Text + "';", connection);
                    IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            int status = 0;
            switch (indexTest)
            {
                // Метод парных сравнений
                case 0:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("Select StatusTest1 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                            status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                // Метод взвешенных экспертных оценок
                case 1:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("Select StatusTest2 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                            status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                // Метод предпочтения
                case 2:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("Select StatusTest3 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                            status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                // Метод ранга
                case 3:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("Select StatusTest4 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                            status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                // Метод полного попарного сравнения
                case 4:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("Select StatusTest5 from ExpertProblems where IdExpert = " + IdExpert.ToString() + " and IdProblem = " + IdProblem.ToString() + ";", connection);
                            status = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
            return status;
        }

        // При выборе другой проблемы
        private void comboBoxProblems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода            
            int status = StatusTests(index);

            if (status == 2) // Эксперт проходил тест ранее, но не закончил
            {
                labelStatus.Text = "Не завершено";
                labelStatus.ForeColor = Color.Red;
            }
            if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
            {
                labelStatus.Text = "Завершено. Возможно изменение ответов";
                labelStatus.ForeColor = Color.DarkCyan;
            }
            if (status == 0) // Оценивание еще не проводилось
            {
                labelStatus.Text = "Не проводилось";
                labelStatus.ForeColor = Color.Black;
            }
        }

        // При выборе другого метода оценивания
        private void comboBoxTests_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
            int status = StatusTests(index);

            if (status == 2) // Эксперт проходил тест ранее, но не закончил
            {
                labelStatus.Text = "Не завершено";
                labelStatus.ForeColor = Color.Red;
            }
            if (status == 1) // Оценивание полностью завершено и результаты отправлены Аналитику
            {
                labelStatus.Text = "Завершено. Возможно изменение ответов";
                labelStatus.ForeColor = Color.DarkCyan;
            }
            if (status == 0) // Оценивание еще не проводилось
            {
                labelStatus.Text = "Не проводилось";
                labelStatus.ForeColor = Color.Black;
            }
        }
    }
}
