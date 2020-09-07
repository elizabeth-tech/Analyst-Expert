using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertAuthorization : Form
    {
        public ExpertAuthorization()
        {
            InitializeComponent();
        }

        // Закрытие окна входа эксперта
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
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

        // Вход. Переход на окно выбора проблемы
        private void buttonExpertLogin_Click(object sender, EventArgs e)
        {
            Close();
            ExpertMenu f = new ExpertMenu();
            f.Show();
        }
    }
}
