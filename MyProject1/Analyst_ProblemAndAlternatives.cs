using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Expert_assessment_methods
{
    public partial class Analyst_ProblemAndAlternatives : Form
    {
        public Analyst_ProblemAndAlternatives()
        {
            InitializeComponent();
        }

        // Функция удаления файлов
        private void DeleteFile(DirectoryInfo dirInfo, string fileName)
        {
            try
            {
                var files = dirInfo.GetFiles(fileName).ToArray();
                foreach (var file in files)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                foreach (var directory in dirInfo.GetDirectories())
                {
                    DeleteFile(directory, fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Загрузка списка проблем
        private async void LoadProblems()
        {   
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("SELECT ProblemName FROM Problems", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    comboBoxProblem.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            comboBoxProblem.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                    comboBoxProblem.Text = comboBoxProblem.Items[0].ToString();

                    // Если выведенная первая проблема проходится каким то экспертом, то изменять ее и ее альтернативы нельзя
                    SqlCommand command2 = new SqlCommand("SELECT Id from Problems where ProblemName=N'" + comboBoxProblem.Text + "'", connection);
                    int IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов                  
                    SqlCommand command3 = new SqlCommand("SELECT count(*) FROM ExpertProblems where IdProblem = " + IdProblem.ToString() + " and (StatusTest1 = 2 or StatusTest2 = 2 or StatusTest3 = 2 or StatusTest4 = 2 or StatusTest5 = 2);", connection);
                    int status = (int)command3.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    
                    // Если в таблице у проблемы в каком-либо тесте есть статус 2 (то есть запрос вернул несколько строк)
                    if (status >= 1)
                    {
                        buttonEditProblem.Enabled = false;
                        buttonDeleteProblem.Enabled = false;
                        buttonEditAlternative.Enabled = false;
                        buttonDeleteAlternative.Enabled = false;
                        buttonAddAlternative.Enabled = false;
                        textBoxAlternativeAdd.Enabled = false;
                        label5.Visible = false;
                        labelAccess.Visible = true;
                        labelAccess.Text = "В данный момент по этой проблеме ведется оценивание экспертом. " +
                            "Вы не можете взаимодействовать с данной проблемой.\nЧтобы проблема стала доступна к взаимодействию," +
                            "дождитесь выполнения экспертом оценивания, либо удалите проблему\nиз назначенных в меню 'Эксперты и назначенные проблемы'";
                    }                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Заполнение таблицы альтернативами
        private async void LoadAlternatives()
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("select Alternatives.AlternativeName" +
                        " from Problems" +
                        " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                        " where Problems.Id = (select Problems.Id from Problems" +
                        " where Problems.ProblemName = N'" + comboBoxProblem.Text + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewAlternatives.Rows.Clear();
                    if (reader.HasRows) // Если у проблемы есть альтернативы
                    {
                        buttonDeleteAlternative.Visible = true;
                        buttonEditAlternative.Visible = true;
                        label5.Visible = true; // Подсказка
                        dataGridViewAlternatives.Visible = true;
                        labelError.Visible = false;
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewAlternatives.Rows.Add();
                            dataGridViewAlternatives.Rows[i].Cells[0].Value = reader.GetString(0);
                            i++;
                        }
                        reader.Close();
                        
                        if (dataGridViewAlternatives.RowCount == 1) // Если у проблемы только одна альтернатива
                        {
                            labelError.Text = "Необходимо внести как минимум две альтернативы, чтобы проблема\n" +
                                "стала доступна для назначения экспертов.\n";
                            labelError.Visible = true;
                        }
                        else
                            labelError.Visible = false;
                    }
                    else // Если у проблемы нет альтернатив
                    {
                        buttonDeleteAlternative.Visible = false;
                        buttonEditAlternative.Visible = false;
                        label5.Visible = false;
                        dataGridViewAlternatives.Visible = false;
                        labelError.Text = "Для данной проблемы еще не добавлены альтернативы.\n" +
                            "Необходимо внести как минимум две альтернативы, чтобы проблема\n" +
                            "стала доступна для назначения экспертов.\n";
                        labelError.Visible = true;
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Перетаскивание окна
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Открытие окна по добавлению проблемы
        private void buttonAddProblem_Click(object sender, EventArgs e)
        {
            Analyst_AddProblem f = new Analyst_AddProblem();
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы добавления проблемы
            {
                LoadProblems(); // Загрузка списка проблем
                comboBoxProblem.Text = Data.newProblem;
                LoadAlternatives(); // Заполнение таблицы альтернативами
            }
        }

        // Открытие окна по редактированию проблемы
        private void buttonEditProblem_Click(object sender, EventArgs e)
        {
            Analyst_EditProblem f = new Analyst_EditProblem();
            Data.nameProblem = comboBoxProblem.Text;
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы редактирования проблемы
            {
                LoadProblems(); // Загрузка списка проблем
                comboBoxProblem.Text = Data.newProblem;
                LoadAlternatives(); // Заполнение таблицы альтернативами
            }
        }

        // Закрыть окно
        private void buttonCloseAnalystProblem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        // Свернуть окно
        private void buttonTurnAnalystProblem_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Перетаскивание окна
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Смена проблемы - смена альтернатив к ней
        private async void comboBoxProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Заполнение таблицы альтернативами
            LoadAlternatives();

            // Проверяем, доступна ли проблема к редактированию\удалению
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command2 = new SqlCommand("SELECT Id from Problems where ProblemName=N'" + comboBoxProblem.Text + "'", connection);
                    int IdProblem = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов                  
                    SqlCommand command3 = new SqlCommand("SELECT count(*) FROM ExpertProblems where IdProblem = " + IdProblem.ToString() + " and (StatusTest1 = 2 or StatusTest2 = 2 or StatusTest3 = 2 or StatusTest4 = 2 or StatusTest5 = 2);", connection);
                    int status = (int)command3.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                    if (status >= 1) // Если есть тесты по статусом 2, то редактирование и удаление невозможно
                    {
                        buttonEditProblem.Enabled = false;
                        buttonDeleteProblem.Enabled = false;
                        buttonEditAlternative.Enabled = false;
                        buttonDeleteAlternative.Enabled = false;
                        buttonAddAlternative.Enabled = false;
                        textBoxAlternativeAdd.Enabled = false;
                        label5.Visible = false;
                        labelAccess.Visible = true;
                        labelAccess.Text = "В данный момент по этой проблеме ведется оценивание экспертом. " +
                            "Вы не можете взаимодействовать с данной проблемой.\nЧтобы проблема стала доступна к взаимодействию," +
                            "дождитесь выполнения экспертом оценивания, либо удалите\nпроблему из назначенных в меню 'Эксперты и назначенные проблемы'";
                    }
                    else
                    {
                        buttonEditProblem.Enabled = true;
                        buttonDeleteProblem.Enabled = true;
                        buttonEditAlternative.Enabled = true;
                        buttonDeleteAlternative.Enabled = true;
                        buttonAddAlternative.Enabled = true;
                        textBoxAlternativeAdd.Enabled = true;
                        label5.Visible = true;
                        labelAccess.Text = "";
                        labelAccess.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Удаление выбранной проблемы
        private async void buttonDeleteProblem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить проблему: \n'" + comboBoxProblem.Text + "'?\nВсе связанные с ней альтернативы также будут удалены!", "Удаление проблемы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();

                        SqlCommand command = new SqlCommand("select Id from Problems where ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                        int IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        // Удаляем саму проблему (включено каскадное удаление в базе, все альтернативы с id этой проблемы также удаляются)
                        SqlCommand command3 = new SqlCommand("delete from Problems where Problems.ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                        command3.ExecuteNonQuery();

                        // Так как проблема была удалена, то нужно удалить все старые результаты методов по этой проблеме (если они есть)
                        DirectoryInfo dirInfo = new DirectoryInfo(@"Data");
                        DeleteFile(dirInfo, IdProblem.ToString() + ".txt");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.Activate();
                LoadProblems(); // Загрузка списка проблем
                LoadAlternatives(); // Заполнение таблицы альтернативами
            }
            else
                this.Activate();
        }

        // Добавление альтернативы
        private async void buttonAddAlternative_Click(object sender, EventArgs e)
        {
            if (textBoxAlternativeAdd.Text != String.Empty) // Если ввели не пустое
            {
                // Получаем id проблемы, к которой нужно добавить альтернативу
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    SqlCommand command = new SqlCommand("select Id from Problems where ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                    int IdProblem;
                    try
                    {
                        await connection.OpenAsync();
                        IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        // Выполняем проверку на дубликат альтернативы
                        SqlCommand command2 = new SqlCommand("select count(*) from Alternatives where AlternativeName=N'" + textBoxAlternativeAdd.Text + "' and IdProblem=" + IdProblem.ToString() + ";", connection);
                        int count = (int)command2.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов
                        if (count > 0) // Если есть дубликат
                        {
                            DialogResult result = MessageBox.Show("Такая альтернатива уже существует!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.OK)
                            {
                                this.Activate();
                                textBoxAlternativeAdd.Clear();
                                this.ActiveControl = textBoxAlternativeAdd;
                            }
                        }
                        else // Если дубликата нет, то вносим в базу альтернативу к выбранной проблеме
                        {
                            SqlCommand command3 = new SqlCommand("insert into Alternatives values(" + IdProblem + ", N'" + textBoxAlternativeAdd.Text + "');", connection);
                            command3.ExecuteNonQuery();
                            
                            // Проверяем, сколько альтернатив у текущей проблемы
                            SqlCommand command4 = new SqlCommand("select count(*) from Alternatives where IdProblem=" + IdProblem.ToString() + ";", connection);
                            int countAlter = (int)command4.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                            // Так как была добавлена новая альтернатива, то нужно удалить все старые результаты методов по этой проблеме (если они есть)
                            DirectoryInfo dirInfo = new DirectoryInfo(@"Data");
                            DeleteFile(dirInfo, IdProblem.ToString() + ".txt");

                            // Изменяем значения статусов тестов на 0
                            command = new SqlCommand("UPDATE ExpertProblems SET StatusTest1=0, StatusTest2=0, StatusTest3=0, StatusTest4=0, StatusTest5=0 where IdProblem=" + IdProblem.ToString(), connection);
                            command.ExecuteNonQuery();

                            // Если у проблемы появляется 2 или более альтернатив, то ее можно назначать эксперту
                            if (countAlter >= 2)
                            {
                                SqlCommand command5 = new SqlCommand("Update Problems set flag = 1 where ProblemName = N'" + comboBoxProblem.Text + "';", connection);
                                command5.ExecuteNonQuery();
                            }

                            textBoxAlternativeAdd.Clear();
                            LoadAlternatives();
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
                DialogResult result = MessageBox.Show("Введите альтернативу!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.OK)
                {
                    this.Activate();
                    textBoxAlternativeAdd.Clear();
                    this.ActiveControl = textBoxAlternativeAdd;
                }
            }
        }

        // Удаление выбранной альтернативы
        private async void buttonDeleteAlternative_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить альтернативу: \n'" + dataGridViewAlternatives.CurrentCell.Value.ToString() + "'?", "Удаление альтернативы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    // Получаем id проблемы, у которой нужно удалять альтернативу
                    SqlCommand command = new SqlCommand("select Id from Problems where ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                    int IdProblem;
                    try
                    {
                        await connection.OpenAsync();
                        IdProblem = (int)command.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        // Удаляем альтернативу
                        SqlCommand command2 = new SqlCommand("delete from Alternatives where AlternativeName=N'" + dataGridViewAlternatives.CurrentCell.Value.ToString() + "' and IdProblem=" + IdProblem.ToString() + ";", connection);
                        command2.ExecuteNonQuery();

                        // Так как была удалена альтернатива, то нужно удалить все старые результаты методов по этой проблеме (если они есть)
                        DirectoryInfo dirInfo = new DirectoryInfo(@"Data");
                        DeleteFile(dirInfo, IdProblem.ToString() + ".txt");

                        // Изменяем значения статусов тестов на 0
                        command = new SqlCommand("UPDATE ExpertProblems SET StatusTest1=0, StatusTest2=0, StatusTest3=0, StatusTest4=0, StatusTest5=0 where IdProblem=" + IdProblem.ToString(), connection);
                        command.ExecuteNonQuery();

                        // Проверяем, сколько альтернатив у текущей проблемы
                        SqlCommand command3 = new SqlCommand("select count(*) from Alternatives where IdProblem=" + IdProblem.ToString() + ";", connection);
                        int countAlter = (int)command3.ExecuteScalar(); // Возвращает первый столбец первой строки в наборе результатов

                        // Если удаляем столько альтернатив, что их становится меньше двух, то текущая проблема не может быть назначена эксперту
                        if (countAlter < 2)
                        {  
                            SqlCommand command4 = new SqlCommand("Update Problems set flag=0 where ProblemName=N'" + comboBoxProblem.Text + "';", connection);
                            command4.ExecuteNonQuery();

                            // Также удаляем проблему из таблицы назначенных
                            SqlCommand command5 = new SqlCommand("delete from ExpertProblems where IdProblem=" + IdProblem.ToString() + ";", connection);
                            command5.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.Activate();
                    LoadAlternatives(); // Заполнение таблицы альтернативами
                }
            }
            else
                this.Activate();
        }

        // Редактирование альтернативы
        private void buttonEditAlternative_Click(object sender, EventArgs e)
        {
            // Сохранение названия редактируемой альтернативы и проблемы
            Data.nameAlternative = dataGridViewAlternatives.CurrentCell.Value.ToString();
            Data.nameProblem = comboBoxProblem.Text;
            Analyst_EditAlternative f = new Analyst_EditAlternative();
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы редактирования проблемы
                LoadAlternatives(); // Заполнение таблицы альтернативами
        }

        // Загрузка формы
        private void Analyst_ProblemAndAlternatives_Load(object sender, EventArgs e)
        {
            LoadProblems(); // Загрузка списка проблем
            LoadAlternatives(); // Заполнение таблицы альтенативами
        }
    }
}
