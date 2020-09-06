using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystAuthorization : Form
    {
        public AnalystAuthorization()
        {
            InitializeComponent();
        }

        // Сворачивание окна входа аналитика
        private void buttonExpertLoginTurn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытие окна входа аналитика
        private void buttonAnalystLoginClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Переключение на окно выбора проблемы
        private void buttonAnalystLogin_Click(object sender, EventArgs e)
        {
            Close();
            AnalystProblem f = new AnalystProblem();
            f.Show();
        }
    }
}
