using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertAuthorization : Form
    {
        public ExpertAuthorization()
        {
            InitializeComponent();
            this.ActiveControl = textBoxPassword;
        }

        // Закрытие окна входа эксперта
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание окна входа эксперта
        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна входа
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Вход
        private void buttonExpertLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                // Проверка на пустой ввод
                if (textBoxPassword.Text == String.Empty)
                {
                    DialogResult result = MessageBox.Show("Необходимо ввести пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.OK)
                    {
                        this.Activate();
                        this.ActiveControl = textBoxPassword;
                    }
                }
                else
                {
                    // Проверка пароля для авторизации. Если запрос не вернул совпадений, то вход невозможен
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Experts WHERE Experts.Password = N'" + textBoxPassword.Text + "' and Experts.FIOExpert = N'" + comboBoxFIO.Text + "';", connection);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count == 0)
                        {
                            DialogResult result = MessageBox.Show("Неверный пароль! Вход невозможен!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxPassword.Clear();
                                this.ActiveControl = textBoxPassword;
                            }
                        }
                        else
                        {
                            Data.nameExpert = comboBoxFIO.Text; // Сохраняем логин (ФИО) эксперта, для дальнейшего использования
                            // Переход на окно основного меню для прохождения тестов
                            Close();
                            ExpertMenu f = new ExpertMenu();
                            f.Show();
                            Form form = Application.OpenForms[0]; 
                            form.Hide(); // Прячем форму выбора эксперта или аналитика
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // При загрузке формы, асинхронно загружаем ФИО всех экспертов в поле ComboBox
        private async void ExpertAuthorization_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT FIOExpert FROM Experts", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        comboBoxFIO.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            comboBoxFIO.Text = comboBoxFIO.Items[0].ToString();
        }

        // Запрет на ввод пробела в поле пароля
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
