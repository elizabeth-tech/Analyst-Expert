using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertProblems : Form
    {
        public ExpertProblems()
        {
            InitializeComponent();
        }

        // Закрытие окна выбора проблемы для эксперта
        private void buttonExpertProblemClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Сворачивание окна проблемы для эксперта
        private void buttonExpertProblemTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Возврат к окну авторизации для эксперта
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
            ExpertAuthorization f = new ExpertAuthorization();
            f.Show();
        }

        // Переход к основному меню с тестами для эксперта
        private void buttonExpertNext_Click(object sender, EventArgs e)
        {
            Close();
            ExpertMenu f = new ExpertMenu();
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
