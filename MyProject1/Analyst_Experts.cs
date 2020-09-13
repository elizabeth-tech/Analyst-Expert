using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_Experts : Form
    {
        public Analyst_Experts()
        {
            InitializeComponent();
        }

        // Загрузка списка экспертов
        public async void LoadExperts()
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select FIOExpert, Position, Competence from Experts;", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxExpert.Items.Clear();
                    textBoxPositionExpert.Clear();
                    textBoxCompetence.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBoxExpert.Items.Add(reader.GetString(0));
                            textBoxPositionExpert.Text = reader.GetString(1);
                            textBoxCompetence.Text = reader.GetInt32(2).ToString();
                        }
                    }
                    reader.Close();
                    comboBoxExpert.Text = comboBoxExpert.Items[0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }    
        }

        // Загрузка списка назначенных проблем
        public async void LoadExpertProblems()
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Problems.ProblemName from ExpertProblems " +
                        "join Problems on Problems.Id = ExpertProblems.IdProblem " +
                        "where IdExpert = (Select Id from Experts where FIOExpert = N'" + comboBoxExpert.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewExpertProblems.Rows.Clear();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewExpertProblems.Rows.Add();
                            dataGridViewExpertProblems.Rows[i].Cells[0].Value = reader.GetString(0);
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
        }

        // Свернуть окно
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
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

        // Закрытие окна
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Открытие окна по добавлению эксперта
        private void buttonAddExpert_Click(object sender, EventArgs e)
        {
            Analyst_AddExpert f = new Analyst_AddExpert();
            f.ShowDialog();
        }

        // Открытие окна по редактированию эксперта
        private void buttonEditExpert_Click(object sender, EventArgs e)
        {
            Data.nameExpert = comboBoxExpert.Text;
            Data.positionExpert = textBoxPositionExpert.Text;
            Data.competenceExpert = Convert.ToInt32(textBoxCompetence.Text);
            Analyst_EditExpert f = new Analyst_EditExpert();
            f.ShowDialog();
        }

        // При активации фокуса загружаем экспертов
        private void Analyst_Experts_Activated(object sender, EventArgs e)
        {
            LoadExperts();
            LoadExpertProblems();
        }

        // При изменении эксперта - меняется информация в полях
        private async void comboBoxExpert_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Position, Competence from Experts where FIOExpert=N'" + comboBoxExpert.Text + "';", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    textBoxPositionExpert.Clear();
                    textBoxCompetence.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            textBoxPositionExpert.Text = reader.GetString(0);
                            textBoxCompetence.Text = reader.GetInt32(1).ToString();
                        }
                    }
                    reader.Close();

                    SqlCommand command2 = new SqlCommand("Select Problems.ProblemName from ExpertProblems " +
                       "join Problems on Problems.Id = ExpertProblems.IdProblem " +
                       "where IdExpert = (Select Id from Experts where FIOExpert = N'" + comboBoxExpert.Text + "');", connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    dataGridViewExpertProblems.Rows.Clear();
                    if (reader2.HasRows)
                    {
                        int i = 0;
                        while (reader2.Read())
                        {
                            dataGridViewExpertProblems.Rows.Add();
                            dataGridViewExpertProblems.Rows[i].Cells[0].Value = reader2.GetString(0);
                            i++;
                        }

                    }
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Удаление эксперта
        private async void buttonDeleteExpert_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эксперта: \n'" + comboBoxExpert.Text + "'?", "Удаление эксперта", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        // Удаляем эксперта
                        SqlCommand command = new SqlCommand("delete from Experts where FIOExpert=N'" + comboBoxExpert.Text + "';", connection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.Activate();
                LoadExperts(); // Загрузка списка эксперт
            }
            else
                this.Activate();
        }

        // Открытие окна с назначением проблемы эксперту
        private async void buttonAddAssignProblem_Click(object sender, EventArgs e)
        {
            int IdExpert = 0;
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert=N'" + comboBoxExpert.Text + "';", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            IdExpert = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Data.IdExpert = IdExpert;
            Analyst_AddAssignProblem f = new Analyst_AddAssignProblem();
            f.ShowDialog();
        }
    }
}
