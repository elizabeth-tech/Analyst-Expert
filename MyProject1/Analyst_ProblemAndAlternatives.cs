using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_ProblemAndAlternatives : Form
    {
        // Строка подключения (физическое расположение локальной базы)
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Test projects\Portfolio\MyProject1\MyProject1\Database.mdf;Integrated Security=True";

        public Analyst_ProblemAndAlternatives()
        {
            InitializeComponent();
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Открытие окна по добавлению проблемы
        private void buttonAddProblem_Click(object sender, EventArgs e)
        {
            Analyst_AddProblem f = new Analyst_AddProblem();
            f.Show();
        }

        // Открытие окна по редактированию проблемы
        private void buttonEditProblem_Click(object sender, EventArgs e)
        {
            Analyst_ProblemEdit f = new Analyst_ProblemEdit();
            f.Show();
        }

        // Закрыть окно
        private void buttonCloseAnalystProblem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        // Свернуть окно
        private void buttonTurnAnalystProblem_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Загрузка формы
        private async void Analyst_ProblemAndAlternatives_Load(object sender, EventArgs e)
        {
            // Загрузка списка проблем
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT Id, ProblemName FROM Problems", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        comboBoxProblem.Items.Add(reader.GetString(1));   
                }
                reader.Close();
            }
            comboBoxProblem.Text = comboBoxProblem.Items[0].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("select Alternatives.AlterantiveName" +
                    " from Problems" +
                    " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                    " where Problems.Id = (select Problems.Id from Problems" +
                    " where Problems.ProblemName = N'" + comboBoxProblem.Text + "')", connection);
                SqlDataReader reader = command.ExecuteReader();
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

        }
    }
}
