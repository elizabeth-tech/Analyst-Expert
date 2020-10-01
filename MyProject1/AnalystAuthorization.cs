using System;
using System.Windows.Forms;

namespace Expert_assessment_methods
{
    public partial class AnalystAuthorization : Form
    {
        public AnalystAuthorization()
        {
            InitializeComponent();
            this.ActiveControl = textBoxPassword;
        }

        // Сворачивание окна входа аналитика
        private void buttonExpertLoginTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытие окна входа аналитика
        private void buttonAnalystLoginClose_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
            Close();
        }

        // Вход. Переключение на основное меню
        private void buttonAnalystLogin_Click(object sender, EventArgs e)
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
                if (textBoxPassword.Text != "1234")
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
                    Form form = Application.OpenForms[0];
                    form.Hide(); // Прячем форму выбора эксперта или аналитика
                    AnalystMenu f = new AnalystMenu();
                    f.Show();
                    Close();
                }
            }
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

    }
}
