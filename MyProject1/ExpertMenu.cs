using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class ExpertMenu : Form
    {
        public ExpertMenu()
        {
            InitializeComponent();
        }

        // Закрытие окна с основным меню для эксперта
        private void buttonExpertProblemClose_Click(object sender, EventArgs e)
        {
            Close();
            Form form = Application.OpenForms[0]; // Вызываем форму выбора эксперта или аналитика
            form.Show();
        }

        // Сворачивание окна с основным меню эксперта
        private void buttonExpertProblemTurn_Click(object sender, EventArgs e)
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

        // Загрузка формы и заполнение comboBox проблемами
        private async void ExpertMenu_Load(object sender, EventArgs e)
        {
            label3.Text = Data.nameExpert.ToString(); // Вывод ФИО эксперта
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT ProblemName FROM Problems", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            comboBox1.Text = comboBox1.Items[0].ToString();
        }
    }
}
