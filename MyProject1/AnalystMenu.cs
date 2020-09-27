using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystMenu : Form
    {
        public AnalystMenu()
        {
            InitializeComponent();
        }

        // Закрытие окна основного меню аналитика
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
            Form f = Application.OpenForms[0];
            f.Show();
        }

        // Сворачивание окна
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Переход на окно проблем и их альтернатив
        private void buttonAnalystProblemsAlternatives_Click(object sender, EventArgs e)
        {
            Analyst_ProblemAndAlternatives f = new Analyst_ProblemAndAlternatives();
            f.ShowDialog();
        }

        // Переход к окну экспертов и их компетентности
        private void buttonExperts_Click(object sender, EventArgs e)
        {
            Analyst_Experts f = new Analyst_Experts();
            f.ShowDialog();
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Переход к окну результатов опроса
        private void buttonResults_Click(object sender, EventArgs e)
        {
            AnalystResults f = new AnalystResults();
            f.ShowDialog();
        }
    }
}
