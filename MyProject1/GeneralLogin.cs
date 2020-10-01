using System;
using System.Windows.Forms;

namespace Expert_assessment_methods
{
    public partial class GeneralLogin : Form
    {
        public GeneralLogin()
        {
            InitializeComponent();
        }

        // Закрытие основной формы входа
        private void buttonCloseLogin_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание основной формы входа
        private void buttonTurnLogin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Вход как Эксперт
        private void buttonExpertLogin_Click(object sender, EventArgs e)
        {
            ExpertAuthorization f = new ExpertAuthorization();
            f.ShowDialog();
        }

        // Вход как Аналитик
        private void buttonAnalystLogin_Click(object sender, EventArgs e)
        {
            AnalystAuthorization f = new AnalystAuthorization();
            f.ShowDialog();
        }

        // Для перетаскивания формы
        private void GeneralLogin_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
