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

        // (Аналитик) Закрытие окна изменения компетентности экспертов
        private void buttonCloseAnalystAlternative_Click(object sender, EventArgs e)
        {
            Close();
            Form f = Application.OpenForms[0];
            f.Show();
        }

        // Сворачивание окна
        private void buttonTurnAnalystAlternative_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Возврат на окно выбора эксперта
        private void buttonAnalystBack_Click(object sender, EventArgs e)
        {
            Analyst_ExpertChoice f = new Analyst_ExpertChoice();
            f.Show();
            Close();
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void кРезультатамToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
