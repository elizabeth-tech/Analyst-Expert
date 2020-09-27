using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_AddExpert : Form
    {
        public Analyst_AddExpert()
        {
            InitializeComponent();
            this.ActiveControl = textBoxFio;
        }

        // Сворачивание окна
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытие окна
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Отмена
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Добавить эксперта
        private async void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxFio.Text != String.Empty) // Если ввели не пустое ФИО
            {
                if (textBoxPositionExpert.Text != String.Empty) // Если ввели не пустую должность
                {
                    if(textBoxCompetence.Text != String.Empty) // Если ввели не пустую компетентность
                    {
                        if (textBoxPassword.Text != String.Empty) // Если ввели не пустой пароль
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
                                        this.DialogResult = DialogResult.OK;
                                        Data.newExpert = textBoxFio.Text;
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
                        }
                    }
                    else // Если пустая строка, то выводим сообщение
                    {
                        DialogResult result = MessageBox.Show("Все поля обязательны к заполнению! Внесите данные о компетентности!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        if (result == DialogResult.OK)
                        {
                            this.Activate();
                            this.ActiveControl = textBoxCompetence;
                        }
                    }
                }
                else // Если пустая строка, то выводим сообщение
                {
                    DialogResult result = MessageBox.Show("Все поля обязательны к заполнению! Внесите данные о должности!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.OK)
                    {
                        this.Activate();
                        this.ActiveControl = textBoxPositionExpert;
                    }
                }
            }
            else // Если пустая строка, то выводим сообщение
            {
                DialogResult result = MessageBox.Show("Все поля обязательны к заполнению! Внесите данные ФИО!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    this.ActiveControl = textBoxFio;
                }
            }
        }

        // Запрет на ввод символов в поле компетентности
        private void textBoxCompetence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        // Запрет на ввод пробела в поле пароля
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
