using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystAlternative : Form
    {
        public AnalystAlternative()
        {
            InitializeComponent();
        }

        // Закрыть окно изменения альтернатив для аналитика
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
            Form f = Application.OpenForms[0]; // Показываю форму главного окна эксперта и аналитика
            f.Show();
        }

        // Свернуть окно изменения альтернатив для аналитика
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна изменения альтернатив для аналитика
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // (Аналитик) Переход на окно выбора экспертов для проблемы
        private void buttonAnalystNext_Click(object sender, EventArgs e)
        {
            Close();
            Analyst_ExpertChoice f = new Analyst_ExpertChoice();
            f.Show();
        }
    }
}
