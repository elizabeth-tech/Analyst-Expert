using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_ProblemAndAlternatives : Form
    {
        public Analyst_ProblemAndAlternatives()
        {
            InitializeComponent();
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Открытие окна по добавлению проблемы
        private void buttonAddProblem_Click(object sender, EventArgs e)
        {
            Analyst_AddProblem f = new Analyst_AddProblem();
            f.Show();
        }

        // Открытие окна по редактированию проблемы
        private void buttonEditProblem_Click(object sender, EventArgs e)
        {
            Analyst_ProblemEdit f = new Analyst_ProblemEdit();
            f.Show();
        }

        // Закрыть окно
        private void buttonCloseAnalystProblem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        // Свернуть окно
        private void buttonTurnAnalystProblem_Click_1(object sender, EventArgs e)
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
    }
}
