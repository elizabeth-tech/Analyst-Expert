using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_AddAssignProblem : Form
    {
        public Analyst_AddAssignProblem()
        {
            InitializeComponent();
        }

        // Закрытие окна
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание окна
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Отмена
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Загрузка списка проблем
        private async void Analyst_AddAssignProblem_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("SELECT Problems.ProblemName FROM Problems" +
                        " left join(select ExpertProblems.IdProblem from ExpertProblems" +
                        " where ExpertProblems.IdExpert = " + Data.IdExpert.ToString() + ")pr on pr.IdProblem = Problems.Id" +
                        " except" +
                        " SELECT Problems.ProblemName FROM Problems" +
                        " join ExpertProblems on ExpertProblems.IdProblem = Problems.Id" +
                        " where ExpertProblems.IdExpert = " + Data.IdExpert.ToString() + ";", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            comboBoxProblems.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                    comboBoxProblems.Text = comboBoxProblems.Items[0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Назначение новой проблемы эксперту (Добавить)
        private void buttonOk_Click(object sender, EventArgs e)
        {
          /*  if (textBoxPassword.Text != String.Empty) // Если ввели не пустой пароль
            {
                // Проверка на дубликат в базе
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    SqlCommand command = new SqlCommand("select count(*) from Experts where FIOExpert=N'" + textBoxFio.Text + "';", connection);
                    try
                    {
                        await connection.OpenAsync();
                        int count = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count > 0) // Если есть дубликат
                        {
                            DialogResult result = MessageBox.Show("Такой эксперт уже существует!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxFio.Clear();
                                this.ActiveControl = textBoxFio;
                            }
                        }
                        else // Если дубликата нет, то вносим в базу
                        {
                            SqlCommand command2 = new SqlCommand("insert into Experts values(N'" + textBoxFio.Text + "', N'" + textBoxPositionExpert.Text + "', " + textBoxCompetence.Text + ", N'" + textBoxPassword.Text + "');", connection);
                            command2.ExecuteNonQuery();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else // Если пустая строка, то выводим сообщение
            {
                DialogResult result = MessageBox.Show("Все поля обязательны к заполнению! Внесите данные о пароле!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    this.ActiveControl = textBoxPassword;
                }
            }*/
        }
    }
}
