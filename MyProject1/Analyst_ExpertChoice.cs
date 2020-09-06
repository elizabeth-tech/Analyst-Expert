using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_ExpertChoice : Form
    {
        public Analyst_ExpertChoice()
        {
            InitializeComponent();
        }

        // Закрытие окна выбора экспертов
        private void buttonCloseAnalystAlternative_Click(object sender, EventArgs e)
        {
            Close();
            Form f = Application.OpenForms[0];
            f.Show();
        }

        // Свернуть окно
        private void buttonTurnAnalystAlternative_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Переход к компетентности экспертов
        private void buttonAnalystNext_Click(object sender, EventArgs e)
        {
            
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
