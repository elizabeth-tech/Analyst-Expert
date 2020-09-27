using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Analyst_AddProblem : Form
    {
        public Analyst_AddProblem()
        {
            InitializeComponent();
            this.ActiveControl = textBoxProblemName; // Перевод фокуса на поле ввода
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

        // Кнопка Ок - добавление проблемы
        private async void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxProblemName.Text != String.Empty) // Если ввели не пустое
            {
                // Проверка на дубликат в базе
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    SqlCommand command = new SqlCommand("select count(*) from Problems where Problems.ProblemName=N'" + textBoxProblemName.Text + "';", connection);
                    try
                    {
                        await connection.OpenAsync();
                        int count = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count > 0) // Если есть дубликат
                        {
                            DialogResult result = MessageBox.Show("Такая проблема уже существует!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxProblemName.Clear();
                                this.ActiveControl = textBoxProblemName;
                            }
                        }
                        else // Если дубликата нет, то вносим в базу
                        {
                            SqlCommand command2 = new SqlCommand("insert into Problems values(N'" + textBoxProblemName.Text + "', 0);", connection);
                            command2.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            Data.newProblem = textBoxProblemName.Text;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
               
            }
            else // Если пустая строка, то выводим сообщение
            {
                DialogResult result = MessageBox.Show("Введите проблему!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    textBoxProblemName.Clear();
                    this.ActiveControl = textBoxProblemName;
                }
            }
        }


    }
}
