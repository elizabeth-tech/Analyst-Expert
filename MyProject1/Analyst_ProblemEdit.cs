using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_ProblemEdit : Form
    {
        public Analyst_ProblemEdit()
        {
            InitializeComponent();
        }

        // Закрыть окно
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Кнопка отмена
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Свернуть окно
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
    }
}
