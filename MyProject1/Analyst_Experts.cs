﻿using System;
using System.Data.SqlClient;
using System.Drawing;
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
                        comboBoxExpert.Text = comboBoxExpert.Items[0].ToString();
                    }
                    reader.Close();
                    
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
                    SqlCommand command = new SqlCommand("Select Problems.ProblemName, StatusTest1, StatusTest2, StatusTest3, StatusTest4, StatusTest5 from ExpertProblems" +
                        " join Problems on Problems.Id = ExpertProblems.IdProblem" +
                        " where IdExpert = (Select Id from Experts where FIOExpert = N'" + comboBoxExpert.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewExpertProblems.Rows.Clear();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewExpertProblems.Rows.Add();
                            dataGridViewExpertProblems.Rows[i].Cells[0].Value = reader.GetString(0);

                            // Заполнение статусов тестов
                            for (int j = 1; j <= 5; j++)
                            {
                                if (reader.GetInt32(j) == 0)
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Не проводилось";
                                if (reader.GetInt32(j) == 1)
                                {
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Завершено";
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(224, 237, 218);
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.SelectionBackColor = Color.FromArgb(224, 237, 218);
                                }
                                if (reader.GetInt32(j) == 2)
                                {
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Не закончено";
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.BackColor = Color.PeachPuff;
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.SelectionBackColor = Color.PeachPuff;
                                }
                            }

                            i++;
                        }
                        
                        label7.Visible = false;
                        dataGridViewExpertProblems.Visible = true;
                        buttonDeleteAssignProblem.Visible = true;
                        label6.Visible = true;
                    }
                    else
                    {
                        label6.Visible = false;
                        buttonDeleteAssignProblem.Visible = false;
                        dataGridViewExpertProblems.Visible = false;
                        label7.Visible = true;
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
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы добавления эксперта
            {
                LoadExperts(); // Загрузка списка экспертов
                comboBoxExpert.Text = Data.newExpert;
                LoadExpertProblems(); // Заполнение соответствующих назначенных проблем
            }
        }

        // Открытие окна по редактированию эксперта
        private async void buttonEditExpert_Click(object sender, EventArgs e)
        {
            Data.nameExpert = comboBoxExpert.Text;
            Data.positionExpert = textBoxPositionExpert.Text;
            Data.competenceExpert = Convert.ToInt32(textBoxCompetence.Text);
            Analyst_EditExpert f = new Analyst_EditExpert();
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы редактирования эксперта
            {
                comboBoxExpert.Text = Data.newExpert;
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select Position, Competence from Experts where FIOExpert=N'" + comboBoxExpert.Text + "'", connection);
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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                LoadExpertProblems(); // Заполнение соответствующих назначенных проблем
            }
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

                    SqlCommand command2 = new SqlCommand("Select Problems.ProblemName, StatusTest1, StatusTest2, StatusTest3, StatusTest4, StatusTest5 from ExpertProblems" +
                       " join Problems on Problems.Id = ExpertProblems.IdProblem" +
                       " where IdExpert = (Select Id from Experts where FIOExpert = N'" + comboBoxExpert.Text + "');", connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    dataGridViewExpertProblems.Rows.Clear();
                    if (reader2.HasRows)
                    {
                        label6.Visible = true;
                        buttonDeleteAssignProblem.Visible = true;
                        dataGridViewExpertProblems.Visible = true;
                        label7.Visible = false;
                        int i = 0;
                        while (reader2.Read())
                        {
                            dataGridViewExpertProblems.Rows.Add();
                            dataGridViewExpertProblems.Rows[i].Cells[0].Value = reader2.GetString(0);

                            // Заполнение статусов тестов
                            for (int j = 1; j <= 5; j++)
                            {
                                if (reader2.GetInt32(j) == 0)
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Не проводилось";
                                if (reader2.GetInt32(j) == 1)
                                {
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Завершено";
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(224, 237, 218);
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.SelectionBackColor = Color.FromArgb(224, 237, 218);
                                }
                                if (reader2.GetInt32(j) == 2)
                                {
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Value = "Не закончено";
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.BackColor = Color.PeachPuff;
                                    dataGridViewExpertProblems.Rows[i].Cells[j].Style.SelectionBackColor = Color.PeachPuff;
                                }
                            }

                            i++;
                        }

                    }
                    else
                    {
                        label6.Visible = false;
                        buttonDeleteAssignProblem.Visible = false;
                        dataGridViewExpertProblems.Visible = false;
                        label7.Visible = true;
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
                LoadExperts();
                LoadExpertProblems();
            }
            else
                this.Activate();
        }

        // Открытие окна с назначением проблемы эксперту
        private async void buttonAddAssignProblem_Click(object sender, EventArgs e)
        {
            int IdExpert = 0;
            // Получаем Id эксперта, которому хотим назначить проблемы
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert=N'" + comboBoxExpert.Text + "';", connection);
                    IdExpert = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Data.IdExpert = IdExpert;
            Analyst_AddAssignProblem f = new Analyst_AddAssignProblem();
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы назначения проблемы эксперту
                LoadExpertProblems(); // Заполнение соответствующих назначенных проблем
        }

        // Удаление назначенной проблемы
        private async void buttonDeleteAssignProblem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите отменить назначенную проблему: \n'" + dataGridViewExpertProblems.Rows[dataGridViewExpertProblems.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'?", "Отмена назначенной проблемы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();

                        // Получаем id проблемы
                        SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + dataGridViewExpertProblems.Rows[dataGridViewExpertProblems.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'", connection);
                        int IdProblem = (int)command.ExecuteScalar();

                        // Получаем id эксперта
                        SqlCommand command2 = new SqlCommand("Select Id from Experts where FIOExpert=N'" + comboBoxExpert.Text + "'", connection);
                        int IdExpert = (int)command2.ExecuteScalar();

                        // Удаляем назначенную проблему
                        SqlCommand command3 = new SqlCommand("delete from ExpertProblems where IdExpert=" + IdExpert.ToString() + " and IdProblem=" + IdProblem.ToString() + ";", connection);
                        command3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.Activate();
                LoadExpertProblems();
            }
            else
                this.Activate();
        }

        // Загрузка формы
        private void Analyst_Experts_Load(object sender, EventArgs e)
        {
            LoadExperts();
            LoadExpertProblems();
        }
    }
}
