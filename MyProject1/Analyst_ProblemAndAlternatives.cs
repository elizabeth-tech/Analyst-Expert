using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_ProblemAndAlternatives : Form
    {
        public Analyst_ProblemAndAlternatives()
        {
            InitializeComponent();
        }

        // Загрузка списка проблем
        public async void LoadProblems()
        {
            comboBoxProblem.Items.Clear();
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
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
        }

        // Заполнение таблицы альтенативами
        private async void LoadAlternatives()
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("select Alternatives.AlterantiveName" +
                    " from Problems" +
                    " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                    " where Problems.Id = (select Problems.Id from Problems" +
                    " where Problems.ProblemName = N'" + comboBoxProblem.Text + "')", connection);
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
            f.ShowDialog();
        }

        // Открытие окна по редактированию проблемы
        private void buttonEditProblem_Click(object sender, EventArgs e)
        {
            Analyst_EditProblem f = new Analyst_EditProblem();
            Data.nameProblem = comboBoxProblem.Text;
            f.ShowDialog();   
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

        // Смена проблемы - смена альтернатив к ней
        private void comboBoxProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Заполнение таблицы альтенативами
            LoadAlternatives();
        }

        // Удаление выбранной проблемы
        private async void buttonDeleteProblem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить проблему: \n'" + comboBoxProblem.Text + "'?", "Удаление проблемы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("delete from Problems where Problems.ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                    command.ExecuteNonQuery();
                }
                this.Activate();
                LoadProblems(); // Загрузка списка проблем
                LoadAlternatives(); // Заполнение таблицы альтенативами
            }
            else
                this.Activate();
        }

        // При активации фокуса - обновляем данные формы
        private void Analyst_ProblemAndAlternatives_Activated(object sender, EventArgs e)
        {
            LoadProblems(); // Загрузка списка проблем
            LoadAlternatives(); // Заполнение таблицы альтенативами
        }
    }
}
