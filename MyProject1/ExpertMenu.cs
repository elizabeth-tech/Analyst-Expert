using System;
using System.Data.SqlClient;
using System.Drawing;
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
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Problems.ProblemName from ExpertProblems " +
                        "join Problems on Problems.Id = ExpertProblems.IdProblem " +
                        "where IdExpert = (Select Id from Experts where FIOExpert = N'" + label3.Text + "');", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        label7.Visible = false;
                        label2.Text = "Есть доступные тесты";
                        label2.ForeColor = Color.Green;
                        comboBox1.Visible = true;

                        while (reader.Read())
                            comboBox1.Items.Add(reader.GetString(0));
                        comboBox1.Text = comboBox1.Items[0].ToString();
                    }
                    else
                    {
                        label7.Visible = true;
                        label2.Text = "Нет доступных тестов";
                        label2.ForeColor = Color.Red;
                        comboBox1.Visible = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Открытие окна метода парных сравнений
        private void button2_Click(object sender, EventArgs e)
        {
            Data.selectedProblem = comboBox1.Text;
            Expert_Method_PairwiseComparison f = new Expert_Method_PairwiseComparison();
            f.ShowDialog();
        }
    }
}
