using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertMenu : Form
    {
        public ExpertMenu()
        {
            InitializeComponent();
        }

        // Закрытие окна с основным меню для эксперта
        private void buttonExpertProblemClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Сворачивание окна с основным меню эксперта
        private void buttonExpertProblemTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Возврат к выбору проблемы
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
            ExpertProblems f = new ExpertProblems();
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
