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
                    // Находим количество экспертов, которое должно пройти оценивание по этой проблеме  
                    SqlCommand command = new SqlCommand("Select count(*) from ExpertProblems where IdProblem=" + IdProblem.ToString(), connection);
                    countExpert = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelError2.ForeColor = Color.Black;
                labelError2.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
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

                // Копируем в матрицу
                double[,] temp = new double[V.Count, dataGridViewAlternatives.RowCount];
                int t = 0;
                foreach (KeyValuePair<int, List<double>> keyValue in V)
                {
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        temp[t, i] += V[keyValue.Key][i];
                    t++;
                }

                // Итоговые веса каждой альтернативы
                double[] result = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                {
                    for (int j = 0; j < V.Count; j++)
                        result[i] += temp[j, i];
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

        // Загрузка результатов для метода 3) Предпочтения
        private void Load_Method3(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError3.ForeColor = Color.Red;
                labelError3.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod3.Visible = false;
            }
            else
            {
                // Словарь, где ключ - IdExpert, а значение - оценки
                Dictionary<int, List<string>> estimates = new Dictionary<int, List<string>>();
                var lines = File.ReadAllLines(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt").ToList();
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
                    // Находим количество экспертов, которое должно пройти оценивание по этой проблеме 
                    SqlCommand command = new SqlCommand("Select count(*) from ExpertProblems where IdProblem=" + IdProblem.ToString(), connection);
                    countExpert = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelError3.ForeColor = Color.Black;
                labelError3.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod3.Visible = true;
                

                // Алгоритм метода предпочтений
                // Модифицированная матрица предпочтений K
                Dictionary<int, List<double>> K = new Dictionary<int, List<double>>();
                foreach (KeyValuePair<int, List<string>> keyValue in estimates)
                {
                    K.Add(keyValue.Key, new List<double>());
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        K[keyValue.Key].Add(dataGridViewAlternatives.RowCount - Convert.ToInt16(keyValue.Value[i]));
                }

                // Копируем в матрицу
                double[,] temp = new double[K.Count, dataGridViewAlternatives.RowCount];
                int t = 0;
                foreach (KeyValuePair<int, List<double>> keyValue in K)
                {
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        temp[t, i] = K[keyValue.Key][i];
                    t++;
                }

                // Суммарные оценки предпочтений по каждой альтернативе
                double[] l = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                {
                    for (int j = 0; j < K.Count; j++)
                        l[i] += temp[j, i];
                }

                // Сумма всех суммарных оценок предпочтений
                double L = 0;
                for (int i = 0; i < l.Length; i++)
                    L += l[i];

                //Вычисляем веса альтернатив
                double[] result = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < l.Length; i++)
                    result[i] = l[i] / L;

                // Выводим данные в таблицу
                dataGridViewMethod3.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod3.Rows.Add();
                    dataGridViewMethod3.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod3.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod3.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod3.Sort(dataGridViewMethod3.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов для метода 4) ранга
        private void Load_Method4(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodRang\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError4.ForeColor = Color.Red;
                labelError4.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod4.Visible = false;
            }
            else
            {
                // Словарь, где ключ - IdExpert, а значение - оценки
                Dictionary<int, List<double>> estimates = new Dictionary<int, List<double>>();
                var lines = File.ReadAllLines(@"Data\MethodRang\" + IdProblem.ToString() + ".txt").ToList();
                foreach (string s in lines) // Строка из файла
                {
                    String[] elements = Regex.Split(s, " ");
                    estimates.Add(Convert.ToInt16(elements[0]), new List<double>());
                    for (int i = 1; i < elements.Length; i++) // Строку превращаем в словарь
                        estimates[Convert.ToInt16(elements[0])].Add(Convert.ToDouble(elements[i]));
                }

                int countExpert = 0;
                try
                {
                    // Находим количество экспертов, которое должно пройти оценивание по этой проблеме 
                    SqlCommand command = new SqlCommand("Select count(*) from ExpertProblems where IdProblem=" + IdProblem.ToString(), connection);
                    countExpert = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelError4.ForeColor = Color.Black;
                labelError4.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod4.Visible = true;

                // Алгоритм метода ранга
                // Для каждого эксперта вычисляется сумма оценок всех альтернатив
                Dictionary<int, double> S = new Dictionary<int, double>();
                foreach (KeyValuePair<int, List<double>> keyValue in estimates)
                    S[keyValue.Key] = estimates[keyValue.Key].Sum();

                // Составляем матрицу нормированных оценок альтернатив
                Dictionary<int, List<double>> R = new Dictionary<int, List<double>>();
                foreach (KeyValuePair<int, List<double>> keyValue in estimates)
                {
                    R.Add(keyValue.Key, new List<double>());
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        R[keyValue.Key].Add(estimates[keyValue.Key][i] / S[keyValue.Key]);

                }

                // Вычисляем искомые веса альтернатив
                // Копируем в матрицу
                double[,] temp = new double[R.Count, dataGridViewAlternatives.RowCount];
                int t = 0;
                foreach (KeyValuePair<int, List<double>> keyValue in R)
                {
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        temp[t, i] = R[keyValue.Key][i];
                    t++;
                }

                // Сумма R по столбцу
                double[] sum_R = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                {
                    for (int j = 0; j < R.Count; j++)
                        sum_R[i] += temp[j, i];
                }

                // Итог
                double[] result = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < sum_R.Length; i++)
                    result[i] = sum_R[i] / estimates.Count;

                // Выводим данные в таблицу
                dataGridViewMethod4.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod4.Rows.Add();
                    dataGridViewMethod4.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod4.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod4.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod4.Sort(dataGridViewMethod4.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов для метода 5) Полного попарного сопоставления
        private void Load_Method5(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\Result5_MethodCompletePairs\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError5.ForeColor = Color.Red;
                labelError5.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod5.Visible = false;
            }
            else
            {
                // Словарь, где ключ - IdExpert, а значение - оценки
                Dictionary<int, List<double>> estimates = new Dictionary<int, List<double>>();
                var lines = File.ReadAllLines(@"Data\Result5_MethodCompletePairs\" + IdProblem.ToString() + ".txt").ToList();
                foreach (string s in lines) // Строка из файла
                {
                    String[] elements = Regex.Split(s, " ");
                    estimates.Add(Convert.ToInt16(elements[0]), new List<double>());
                    for (int i = 1; i < elements.Length; i++) // Строку превращаем в словарь
                        estimates[Convert.ToInt16(elements[0])].Add(Convert.ToDouble(elements[i]));
                }

                int countExpert = 0;
                try
                {
                    // Находим количество экспертов, которое должно пройти оценивание по этой проблеме 
                    SqlCommand command = new SqlCommand("Select count(*) from ExpertProblems where IdProblem=" + IdProblem.ToString(), connection);
                    countExpert = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                labelError5.ForeColor = Color.Black;
                labelError5.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod5.Visible = true;

                // Алгоритм полного попарного сопоставления
                // Копируем в матрицу
                double[,] temp = new double[estimates.Count, dataGridViewAlternatives.RowCount];
                int t = 0;
                foreach (KeyValuePair<int, List<double>> keyValue in estimates)
                {
                    for (int i = 0; i < keyValue.Value.Count; i++)
                        temp[t, i] = estimates[keyValue.Key][i];
                    t++;
                }

                // Определяем искомые веса альтернатив
                double[] result = new double[dataGridViewAlternatives.RowCount];
                for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                {
                    for (int j = 0; j < estimates.Count; j++)
                        result[i] += temp[j, i];
                }

                // Выводим данные в таблицу
                dataGridViewMethod5.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod5.Rows.Add();
                    dataGridViewMethod5.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod5.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod5.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod5.Sort(dataGridViewMethod5.Columns[2], ListSortDirection.Descending);
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
                    SqlCommand command = new SqlCommand("SELECT distinct ProblemName FROM Problems" +
                        " join ExpertProblems on ExpertProblems.IdProblem = Problems.Id" +
                        " where flag = 1", connection);
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
                    
                    Load_Method2(connection, IdProblem); // Загрузка данных для метода 2) взвешенных оценок
                    Load_Method3(connection, IdProblem); // Загрузка данных для метода 3) предпочтения
                    Load_Method4(connection, IdProblem); // Загрузка данных для метода 4) ранга
                    Load_Method5(connection, IdProblem); // Загрузка данных для метода 5) полного попарного сопоставления
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

                    Load_Method2(connection, IdProblem); // Загрузка данных для метода 2) взвешенных оценок
                    Load_Method3(connection, IdProblem); // Загрузка данных для метода 3) предпочтения
                    Load_Method4(connection, IdProblem); // Загрузка данных для метода 4) ранга
                    Load_Method5(connection, IdProblem); // Загрузка данных для метода 5) полного попарного сопоставления
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

        // Метод 2) При убирании мышки со всплывающего списка экспертов - прячем его
        private void richTextBoxExpertsMethod2_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxExpertsMethod2.Visible = false;
            buttonExpertListMethod2.Visible = true;
        }

        // Метод 2) При наведении на кнопку - показываем список экспертов
        private async void buttonExpertListMethod2_MouseEnter(object sender, EventArgs e)
        {
            buttonExpertListMethod2.Visible = false;
            richTextBoxExpertsMethod2.Clear();

            // Загружаем список экспертов и соответствующий значок в richTextBox
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем Id выведенной в Combobox проблемы
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка экспертов, которые прошли оценивание
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest2 = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod2.AppendText("  " + "✓ " + reader.GetString(0) + "\n");
                    }
                    reader.Close();

                    // Загрузка экспертов, которые не прошли оценивание т.е статус 0, либо 2
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest2 = 0" +
                        " or ExpertProblems.StatusTest2 = 2", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod2.AppendText("  " + "X " + reader.GetString(0) + "\n");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            richTextBoxExpertsMethod2.Select(0, 0);
            richTextBoxExpertsMethod2.ScrollToCaret(); // Чтобы scrollbar не прокручивался
            richTextBoxExpertsMethod2.Visible = true;
        }

        // Метод 3) При наведении на кнопку - показываем список экспертов
        private async void buttonExpertListMethod3_MouseEnter(object sender, EventArgs e)
        {
            buttonExpertListMethod3.Visible = false;
            richTextBoxExpertsMethod3.Clear();

            // Загружаем список экспертов и соответствующий значок в richTextBox
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем Id выведенной в Combobox проблемы
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка экспертов, которые прошли оценивание
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest3 = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod3.AppendText("  " + "✓ " + reader.GetString(0) + "\n");
                    }
                    reader.Close();

                    // Загрузка экспертов, которые не прошли оценивание т.е статус 0, либо 2
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest3 = 0" +
                        " or ExpertProblems.StatusTest3 = 2", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod3.AppendText("  " + "X " + reader.GetString(0) + "\n");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            richTextBoxExpertsMethod3.Select(0, 0);
            richTextBoxExpertsMethod3.ScrollToCaret(); // Чтобы scrollbar не прокручивался
            richTextBoxExpertsMethod3.Visible = true;
        }

        // Метод 3) При убирании мышки со всплывающего списка экспертов - прячем его
        private void richTextBoxExpertsMethod3_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxExpertsMethod3.Visible = false;
            buttonExpertListMethod3.Visible = true;
        }

        // Метод 4) При наведении на кнопку - показываем список экспертов
        private async void buttonExpertListMethod4_MouseEnter(object sender, EventArgs e)
        {
            buttonExpertListMethod4.Visible = false;
            richTextBoxExpertsMethod4.Clear();

            // Загружаем список экспертов и соответствующий значок в richTextBox
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем Id выведенной в Combobox проблемы
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка экспертов, которые прошли оценивание
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest4 = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod4.AppendText("  " + "✓ " + reader.GetString(0) + "\n");
                    }
                    reader.Close();

                    // Загрузка экспертов, которые не прошли оценивание т.е статус 0, либо 2
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest4 = 0" +
                        " or ExpertProblems.StatusTest4 = 2", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod4.AppendText("  " + "X " + reader.GetString(0) + "\n");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            richTextBoxExpertsMethod4.Select(0, 0);
            richTextBoxExpertsMethod4.ScrollToCaret(); // Чтобы scrollbar не прокручивался
            richTextBoxExpertsMethod4.Visible = true;
        }

        // Метод 4) При убирании мышки со всплывающего списка экспертов - прячем его
        private void richTextBoxExpertsMethod4_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxExpertsMethod4.Visible = false;
            buttonExpertListMethod4.Visible = true;
        }

        // Метод 5) При наведении на кнопку - показываем список экспертов
        private async void buttonExpertListMethod5_MouseEnter(object sender, EventArgs e)
        {
            buttonExpertListMethod5.Visible = false;
            richTextBoxExpertsMethod5.Clear();

            // Загружаем список экспертов и соответствующий значок в richTextBox
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем Id выведенной в Combobox проблемы
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();

                    // Загрузка экспертов, которые прошли оценивание
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest5 = 1", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod5.AppendText("  " + "✓ " + reader.GetString(0) + "\n");
                    }
                    reader.Close();

                    // Загрузка экспертов, которые не прошли оценивание т.е статус 0, либо 2
                    command = new SqlCommand("Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest5 = 0" +
                        " or ExpertProblems.StatusTest5 = 2", connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            richTextBoxExpertsMethod5.AppendText("  " + "X " + reader.GetString(0) + "\n");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            richTextBoxExpertsMethod5.Select(0, 0);
            richTextBoxExpertsMethod5.ScrollToCaret(); // Чтобы scrollbar не прокручивался
            richTextBoxExpertsMethod5.Visible = true;
        }

        // Метод 5) При убирании мышки со всплывающего списка экспертов - прячем его
        private void richTextBoxExpertsMethod5_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxExpertsMethod5.Visible = false;
            buttonExpertListMethod5.Visible = true;
        }
    }
}
