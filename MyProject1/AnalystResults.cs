using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class AnalystResults : Form
    {
        public AnalystResults()
        {
            InitializeComponent();
        }

        // Закрыть окно
        private void buttonExpertMenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Свернуть окно
        private void buttonExpertMenuTurn_Click(object sender, EventArgs e)
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

        // Загрузка результатов для метода 2) Взвешенных экспертных оценок
        private void Load_Method2(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodWeightedAssessments\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError2.ForeColor = Color.Red;
                labelError2.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod2.Visible = false;
            }
            else
            {
                // Словарь, где ключ - IdExpert, а значение - оценки
                Dictionary<int, List<string>> estimates = new Dictionary<int, List<string>>();
                var lines = File.ReadAllLines(@"Data\MethodWeightedAssessments\" + IdProblem.ToString() + ".txt").ToList();
                foreach (string s in lines) // Строка из файла
                {
                    String[] elements = Regex.Split(s, " ");
                    estimates.Add(Convert.ToInt16(elements[0]), new List<string>());
                    for (int i = 1; i < elements.Length; i++) // Строку превращаем в словарь
                        estimates[Convert.ToInt16(elements[0])].Add(elements[i]);
                }

                int countExpert = 0;
                try
                {
                    // Находим компетентность экспертов, которые прошли тест и вносим в словарь Id-компетентность (ключ-значение) 
                    SqlCommand command = new SqlCommand("Select count(*) from ExpertProblems where IdProblem=" + IdProblem.ToString(), connection);
                    countExpert = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelError2.ForeColor = Color.Black;
                labelError2.Text = "Ранжирование альтернатив на основе оценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod2.Visible = true;

                // Находим компетентность экспертов, которые прошли тест и вносим в словарь Id-компетентность (ключ-значение) 
                Dictionary<int, double> competence = new Dictionary<int, double>();
                try
                {
                    SqlCommand command = new SqlCommand("Select Id, Competence from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.StatusTest2 = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // Если нашли Id и компетентность
                    {
                        while (reader.Read())
                            competence.Add(reader.GetInt32(0), Convert.ToDouble(reader.GetInt32(1)));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Определение относительных оценок компетенций экспертов (сумма компетентности)
                double R = 0;
                foreach (KeyValuePair<int, double> keyValue in competence)
                    R += keyValue.Value;

                // Делим каждую компетентность на сумму
                foreach (var key in competence.Keys.ToArray())
                    competence[key] /= R;

                // Умножаем оценки на соответствующую компетентность
                Dictionary<int, List<double>> V = new Dictionary<int, List<double>>();
                foreach (KeyValuePair<int, List<string>> keyValue in estimates)
                {
                    V.Add(keyValue.Key, new List<double>());
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        V[keyValue.Key].Add(Convert.ToDouble(keyValue.Value[i]) * competence[keyValue.Key]);
                }

                // Итоговые веса каждой альтернативы
                double[] result = new double[dataGridViewAlternatives.RowCount];
                for (int i = V.Count - 1; i >= 0; i--)
                {
                    var item = V.ElementAt(i);
                    for (int j = 0; j < item.Value.Count; j++)
                        result[j] += V[V.ElementAt(i).Key][j];
                }

                // Выводим данные в таблицу
                dataGridViewMethod2.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod2.Rows.Add();
                    dataGridViewMethod2.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod2.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod2.Rows[j].Cells[2].Value = result[j].ToString(); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod2.Sort(dataGridViewMethod2.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка формы
        private async void AnalystResults_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Загрузка проблем
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("SELECT ProblemName FROM Problems where flag = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            comboBoxProblems.Items.Add(reader.GetString(0));
                        comboBoxProblems.Text = comboBoxProblems.Items[0].ToString();
                    }
                    reader.Close();

                    // Загрузка альтернатив
                    command = new SqlCommand("select Alternatives.AlternativeName" +
                        " from Problems" +
                        " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                        " where Problems.Id = (select Problems.Id from Problems" +
                        " where Problems.ProblemName = N'" + comboBoxProblems.Text + "')", connection);
                    reader = command.ExecuteReader();
                    dataGridViewAlternatives.Rows.Clear();
                    if (reader.HasRows) // Если у проблемы есть альтернативы
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewAlternatives.Rows.Add();
                            dataGridViewAlternatives.Rows[i].Cells[0].Value = i.ToString();
                            dataGridViewAlternatives.Rows[i].Cells[1].Value = reader.GetString(0);
                            i++;
                        }   
                    }
                    reader.Close();

                    // Получаем Id первой выведенной в Combobox проблемы
                    command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка списка экспертов для первой отображенной проблемы, для метода парных сравнений, у которых статус 1 (т.е. тест пройден)
                    command = new SqlCommand("Select distinct Experts.FIOExpert from ExpertProblems" +
                        " join Experts on Experts.Id = ExpertProblems.IdExpert" +
                        " where ExpertProblems.StatusTest1 = 1 and ExpertProblems.IdProblem = " + IdProblem.ToString(), connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        comboBoxExperts.Items.Clear();
                        while (reader.Read())
                            comboBoxExperts.Items.Add(reader.GetString(0));
                        comboBoxExperts.Text = comboBoxExperts.Items[0].ToString();
                    }
                    else
                    {
                        comboBoxExperts.Items.Clear();
                        comboBoxExperts.Items.Add("(нет)");
                        comboBoxExperts.Text = "(нет)";
                        dataGridViewMethod1.Visible = false;
                        labelError1.Visible = true;
                        labelError1.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                    }
                    reader.Close();

                    // Загрузка данных для метода 2) взвешенных оценок
                    Load_Method2(connection, IdProblem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Смена проблемы - смена альтернатив к ней и смена списка экспертов
        private async void comboBoxProblems_SelectedIndexChanged(object sender, EventArgs e)
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
                       " where Problems.ProblemName = N'" + comboBoxProblems.Text + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewAlternatives.Rows.Clear();
                    if (reader.HasRows) // Если у проблемы есть альтернативы
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewAlternatives.Rows.Add();
                            dataGridViewAlternatives.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridViewAlternatives.Rows[i].Cells[1].Value = reader.GetString(0);
                            i++;
                        }
                        reader.Close();
                    }

                    // Получаем Id выведенной в Combobox проблемы
                    command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка списка экспертов для отображенной проблемы, для метода парных сравнений, у которых статус 1 (т.е. тест пройден)
                    command = new SqlCommand("Select distinct Experts.FIOExpert from ExpertProblems" +
                        " join Experts on Experts.Id = ExpertProblems.IdExpert" +
                        " where ExpertProblems.StatusTest1 = 1 and ExpertProblems.IdProblem = " + IdProblem.ToString(), connection);
                    SqlDataReader reader3 = command.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        comboBoxExperts.Items.Clear();
                        dataGridViewMethod1.Visible = true;
                        labelError1.Visible = false;
                        while (reader3.Read())
                            comboBoxExperts.Items.Add(reader3.GetString(0));
                        comboBoxExperts.Text = comboBoxExperts.Items[0].ToString();
                    }
                    else
                    {
                        comboBoxExperts.Items.Clear();
                        comboBoxExperts.Items.Add("(нет)");
                        comboBoxExperts.Text = "(нет)";
                        dataGridViewMethod1.Visible = false;
                        labelError1.Visible = true;
                        labelError1.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                    }
                    reader3.Close();

                    // Загрузка данных для метода 2) взвешенных оценок
                    Load_Method2(connection, IdProblem);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Смена эксперта для первого метода - смена результатов
        private async void comboBoxExperts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExperts.Text != "(нет)")
            {
                // Находим Id эксперта (т.е папку с проблемой) и Id проблемы (т.е файл с результатом)
                int IdExpert = 001, IdProblem = 001;
                using (SqlConnection connection = new SqlConnection(Data.connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand("Select Id from Experts where FIOExpert=N'" + comboBoxExperts.Text + "'", connection);
                        IdExpert = (int)command.ExecuteScalar();

                        command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                        IdProblem = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // Считываем результат в таблицу
                using (StreamReader SR = new StreamReader("Data/Result1_MethodComparison/" + IdExpert.ToString() + "/" + IdProblem.ToString() + ".txt"))
                {
                    dataGridViewMethod1.Rows.Clear();
                    int row = 0;
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        dataGridViewMethod1.Rows.Add();
                        dataGridViewMethod1[0, row].Value = row + 1; // Номер альтернативы
                        dataGridViewMethod1[1, row].Value = dataGridViewAlternatives[1, row].Value; // Название альтернативы
                        dataGridViewMethod1[2, row].Value = String.Format("{0:0.###}", Convert.ToDouble(line)); // Вес альтернативы
                        row++;
                    }
                    SR.Close();
                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod1.Sort(dataGridViewMethod1.Columns[2], ListSortDirection.Descending);

            }

        }
    }
}
