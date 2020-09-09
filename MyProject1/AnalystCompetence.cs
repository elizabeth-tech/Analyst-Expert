using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystCompetence : Form
    {
        public AnalystCompetence()
        {
            InitializeComponent();
        }

        // Свернуть окно
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Открытие окна по добавлению эксперта
        private void buttonAddExpert_Click(object sender, EventArgs e)
        {
            Analyst_AddExpert f = new Analyst_AddExpert();
            f.Show();
        }

        // Открытие окна по редактированию эксперта
        private void buttonEditExpert_Click(object sender, EventArgs e)
        {
            Analyst_EditExpert f = new Analyst_EditExpert();
            f.Show();
        }

    }
}
