﻿using System;
using System.Data.SqlClient;
using System.Drawing;
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
                    // Для назначения новой проблемы, показываем только те, которые еще не были назначены конкретному эксперту 
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
                        comboBoxProblems.Text = comboBoxProblems.Items[0].ToString();
                    }
                    else
                    {
                        label3.Visible = false;
                        comboBoxProblems.Visible = false;
                        label2.Visible = true;
                        buttonOk.BackColor = Color.Gainsboro;
                        buttonOk.Enabled = false;
                    }
                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Назначение новой проблемы эксперту (Добавить)
        private async void buttonOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    // Получаем id проблемы, которую хотим назначить эксперту
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "'", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Добавляем в базу информацию о назначенной проблеме
                    SqlCommand command2 = new SqlCommand("insert into ExpertProblems values(" + Data.IdExpert.ToString() + "," + IdProblem.ToString() + ");", connection);
                    command2.ExecuteNonQuery();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
