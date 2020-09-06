using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystProblem : Form
    {
        public AnalystProblem()
        {
            InitializeComponent();
        }

        // Закрытие окна аналитика с Проблемами
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Сворачивание основной формы входа
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Переход к окну с изменением альтернатив для проблемы
        private void buttonAnalystNext_Click(object sender, EventArgs e)
        {
            Close();
            AnalystAlternative f = new AnalystAlternative();
            f.Show();
        }
    }
}
