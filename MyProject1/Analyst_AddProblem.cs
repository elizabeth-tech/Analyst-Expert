using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_AddProblem : Form
    {
        public Analyst_AddProblem()
        {
            InitializeComponent();
        }

        // Закрытие окна
        private void buttonCloseAnalystProblem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание окна
        private void buttonTurnAnalystProblem_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Отмена
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
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
