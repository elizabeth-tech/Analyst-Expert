using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Expert_assessment_methods
{
    public partial class Analyst_EditProblem : Form
    {
        public Analyst_EditProblem()
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

        // Сохранение измененной проблемы
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNewProblemName.Text != String.Empty) // Если поле для новой проблемы не пустое
            {
                // Проверка на дубликат в базе
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    SqlCommand command = new SqlCommand("select count(*) from Problems where ProblemName=N'" + textBoxNewProblemName.Text + "';", connection);
                    try
                    {
                        await connection.OpenAsync();
                        int count = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count > 0) // Если есть дубликат
                        {
                            DialogResult result = MessageBox.Show("Такая проблема уже существует!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxNewProblemName.Clear();
                                this.ActiveControl = textBoxNewProblemName;
                            }
                        }
                        else // Если дубликата нет, то вносим в базу
                        {
                            SqlCommand command2 = new SqlCommand("Update Problems set ProblemName=N'" + textBoxNewProblemName.Text + "' where ProblemName=N'" + textBoxProblemName.Text + "';", connection);
                            command2.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            Data.newProblem = textBoxNewProblemName.Text;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Введите новую формулировку проблемы!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    textBoxNewProblemName.Clear();
                    this.ActiveControl = textBoxNewProblemName;
                }
            }
        }

        // Загрузка формы, отображение названия проблемы
        private void Analyst_EditProblem_Load(object sender, EventArgs e)
        {
            textBoxProblemName.Text = Data.nameProblem.ToString();
            this.ActiveControl = textBoxNewProblemName;
        }

    }
}
