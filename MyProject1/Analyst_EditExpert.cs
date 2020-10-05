using System;
using System.Data.SqlClient;
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

        // Запрет на ввод символов в поле компетентности
        private void textBoxCompetence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        // Запрет на ввод пробела в поле пароля
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        // Сохранение отредактированного
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNewPositionExpert.Text != String.Empty) // Если поле должности эксперта не пустое
            {
                if (textBoxNewCompetence.Text != String.Empty) // Если поле компетентности не пустое
                {
                    if (Convert.ToInt16(textBoxNewCompetence.Text) >= 1 && Convert.ToInt16(textBoxNewCompetence.Text) <= 10) // Если компетентность [1;10]
                    {
                        using (SqlConnection connection = new SqlConnection(Data.connectionString))
                        {
                            try
                            {
                                await connection.OpenAsync();
                                SqlCommand command = new SqlCommand("Update Experts SET Position=N'" + textBoxNewPositionExpert.Text + "', Competence=" + textBoxNewCompetence.Text + " where FIOExpert=N'" + textBoxFIO.Text + "';", connection);
                                command.ExecuteNonQuery();
                                this.DialogResult = DialogResult.OK;
                                Data.newExpert = textBoxFIO.Text;
                                Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Компетентность должна быть числом от 1 до 10!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        if (result == DialogResult.OK)
                        {
                            this.Activate();
                            this.ActiveControl = textBoxNewCompetence;
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Введите компетентность эксперта!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.OK)
                    {
                        this.Activate();
                        this.ActiveControl = textBoxNewCompetence;
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Введите должность эксперта!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    this.ActiveControl = textBoxNewPositionExpert;
                }
            }     
        }

        // Загрузка формы, заполнение старых значений
        private void Analyst_EditExpert_Load(object sender, EventArgs e)
        {
            textBoxFIO.Text = Data.nameExpert;
            textBoxPositionExpert.Text = Data.positionExpert;
            textBoxCompetence.Text = Data.competenceExpert.ToString();
            this.ActiveControl = textBoxNewPositionExpert;
        }
    }
}
