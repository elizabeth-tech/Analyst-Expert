﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_EditAlternative : Form
    {
        public Analyst_EditAlternative()
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

        // Кнопка отмена
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сохранить альтернативу
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNewAlternativeName.Text != String.Empty) // Если поле для новой альтернативы не пустое
            {
                // Проверка на дубликат в базе
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    SqlCommand command = new SqlCommand("select count(*) from Alternatives where AlternativeName=N'" + textBoxNewAlternativeName.Text + "';", connection);
                    try
                    {
                        await connection.OpenAsync();
                        int count = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count > 0) // Если есть дубликат
                        {
                            DialogResult result = MessageBox.Show("Такая альтернатива уже существует!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxNewAlternativeName.Clear();
                                this.ActiveControl = textBoxNewAlternativeName;
                            }
                        }
                        else // Если дубликата нет, то вносим в базу
                        {
                            // Получаем id проблемы, у которой нужно редактировать альтернативу
                            SqlCommand command2 = new SqlCommand("select Id from Problems where ProblemName=N'" + Data.nameProblem + "';", connection);
                            int IdProblem;
                            IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                           
                            // Вносим измененную альтернативу
                            SqlCommand command3 = new SqlCommand("UPDATE Alternatives SET AlternativeName=N'" + textBoxNewAlternativeName.Text + "' WHERE IdProblem=" + IdProblem.ToString() + " and AlternativeName=N'" + textBoxAlternativeName.Text + "';", connection);
                            command3.ExecuteNonQuery();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else // Если вводим пустое поле
            {
                DialogResult result = MessageBox.Show("Введите новую формулировку альтернативы!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    textBoxNewAlternativeName.Clear();
                    this.ActiveControl = textBoxNewAlternativeName;
                }
            }

        }

        // Загрузка формы, отображение редактируемой альтернативы
        private void Analyst_EditAlternative_Load(object sender, EventArgs e)
        {
            textBoxAlternativeName.Text = Data.nameAlternative;
            this.ActiveControl = textBoxNewAlternativeName;
        }
    }
}
