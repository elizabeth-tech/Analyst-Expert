using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_EditExpert : Form
    {
        public Analyst_EditExpert()
        {
            InitializeComponent();
        }

        // Сворачивание окна
        private void buttonTurnAnalystProblem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытие окна
        private void buttonCloseAnalystProblem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Отмена
        private void button1_Click(object sender, EventArgs e)
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
