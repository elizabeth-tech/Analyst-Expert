using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystAuthorization : Form
    {
        public AnalystAuthorization()
        {
            InitializeComponent();
        }

        // Сворачивание окна входа аналитика
        private void buttonExpertLoginTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытие окна входа аналитика
        private void buttonAnalystLoginClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Переключение на основное меню
        private void buttonAnalystLogin_Click(object sender, EventArgs e)
        {
            Close();
            AnalystMenu f = new AnalystMenu();
            f.Show();
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
