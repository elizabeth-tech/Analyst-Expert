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

        // Загрузка формы
        private async void AnalystResults_Load(object sender, EventArgs e)
        {
            comboBoxTests.Text = comboBoxTests.Items[0].ToString(); // Выводим первый метод (парных сравнений)

            // Показываем combobox с экспертами для метода парных сравнений
            label5.Visible = true;
            comboBoxExperts.Visible = true;
            dataGridViewExperts.Visible = false; // Убираем таблицу экспертов

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
                        Load_Method1();
                    }
                    else
                    {
                        comboBoxExperts.Items.Clear();
                        comboBoxExperts.Items.Add("(нет)");
                        comboBoxExperts.Text = "(нет)";
                        dataGridViewMethod.Visible = false;
                        labelError.Visible = true;
                        labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Загрузка данных для метода 1) парных сравнений
        private async void Load_Method1()
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
                    dataGridViewMethod.Rows.Clear();
                    int row = 0;
                    string line;
                    while ((line = SR.ReadLine()) != null)
                    {
                        dataGridViewMethod.Rows.Add();
                        dataGridViewMethod[0, row].Value = row + 1; // Номер альтернативы
                        dataGridViewMethod[1, row].Value = dataGridViewAlternatives[1, row].Value; // Название альтернативы
                        dataGridViewMethod[2, row].Value = String.Format("{0:0.###}", Convert.ToDouble(line)); // Вес альтернативы
                        row++;
                    }
                    SR.Close();
                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod.Sort(dataGridViewMethod.Columns[2], ListSortDirection.Descending);

            }
        }

        // Загрузка результатов для метода 2) Взвешенных экспертных оценок
        private void Load_Method2(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodWeightedAssessments\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError.Visible = true;
                labelError.ForeColor = Color.Red;
                labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod.Visible = false;
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

                labelError.Visible = true;
                labelError.ForeColor = Color.Black;
                labelError.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod.Visible = true;

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
                dataGridViewMethod.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod.Rows.Add();
                    dataGridViewMethod.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod.Rows[j].Cells[2].Value = result[j].ToString(); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod.Sort(dataGridViewMethod.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов для метода 3) Предпочтения
        private void Load_Method3(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodPreference\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError.Visible = true;
                labelError.ForeColor = Color.Red;
                labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod.Visible = false;
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

                labelError.Visible = true;
                labelError.ForeColor = Color.Black;
                labelError.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod.Visible = true;
                

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
                dataGridViewMethod.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod.Rows.Add();
                    dataGridViewMethod.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod.Sort(dataGridViewMethod.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов для метода 4) ранга
        private void Load_Method4(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\MethodRang\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError.Visible = true;
                labelError.ForeColor = Color.Red;
                labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod.Visible = false;
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

                labelError.Visible = true;
                labelError.ForeColor = Color.Black;
                labelError.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod.Visible = true;

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
                dataGridViewMethod.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod.Rows.Add();
                    dataGridViewMethod.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod.Sort(dataGridViewMethod.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов для метода 5) Полного попарного сопоставления
        private void Load_Method5(SqlConnection connection, int IdProblem)
        {
            // Считываем результат в память
            FileInfo fileInfo = new FileInfo(@"Data\Result5_MethodCompletePairs\" + IdProblem.ToString() + ".txt");
            if (!fileInfo.Exists) // Если файл не существует
            {
                labelError.Visible = true;
                labelError.ForeColor = Color.Red;
                labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                dataGridViewMethod.Visible = false;
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

                labelError.Visible = true;
                labelError.ForeColor = Color.Black;
                labelError.Text = "Ранжирование альтернатив на основе\nоценок " + estimates.Count.ToString() + " из " + countExpert.ToString() + " эксперта(ов)";
                dataGridViewMethod.Visible = true;

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
                dataGridViewMethod.Rows.Clear();
                for (int j = 0; j < result.Length; j++)
                {
                    dataGridViewMethod.Rows.Add();
                    dataGridViewMethod.Rows[j].Cells[0].Value = (j + 1).ToString(); // Номер
                    dataGridViewMethod.Rows[j].Cells[1].Value = dataGridViewAlternatives[1, j].Value; // Название альтернативы
                    dataGridViewMethod.Rows[j].Cells[2].Value = String.Format("{0:0.###}", Convert.ToDouble(result[j])); // Вес

                }
                // Сортируем по убыванию веса альтернатив
                dataGridViewMethod.Sort(dataGridViewMethod.Columns[2], ListSortDirection.Descending);
            }
        }

        // Загрузка результатов в таблицу, в зависимости от выбранного метода
        private async void LoadMethods()
        {
            // Получаем Id выведенной в Combobox проблемы
            int IdProblem = 001;
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    IdProblem = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            int index = comboBoxTests.Items.IndexOf(comboBoxTests.Text); // Номер метода
            switch (index)
            {
                // Метод парных сравнений
                case 0:                    
                    label5.Visible = true;
                    comboBoxExperts.Visible = true; // Показываем combobox с экспертами для метода парных сравнений
                    dataGridViewExperts.Visible = false;
                    dataGridViewMethod.Visible = true;
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            // Загрузка списка экспертов для первой отображенной проблемы, для метода парных сравнений, у которых статус 1 (т.е. тест пройден)
                            SqlCommand command = new SqlCommand("Select distinct Experts.FIOExpert from ExpertProblems" +
                        " join Experts on Experts.Id = ExpertProblems.IdExpert" +
                        " where ExpertProblems.StatusTest1 = 1 and ExpertProblems.IdProblem = " + IdProblem.ToString(), connection);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                labelError.Visible = false;
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
                                dataGridViewMethod.Visible = false;
                                labelError.Visible = true;
                                labelError.Text = "Для данной проблемы ни один эксперт не прошел\nоценивание";
                            }
                            reader.Close();
                            Load_Method1();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

                // Метод взвешенных экспертных оценок
                case 1:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            Load_Method2(connection, IdProblem);
                            LoadExperts(index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

                // Метод предпочтения
                case 2:

                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            Load_Method3(connection, IdProblem);
                            LoadExperts(index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

                // Метод ранга
                case 3:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            Load_Method4(connection, IdProblem);
                            LoadExperts(index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

                // Метод полного попарного сравнения
                case 4:
                    using (SqlConnection connection = new SqlConnection(Data.connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            Load_Method5(connection, IdProblem);
                            LoadExperts(index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
        }

        // Смена метода оценивания
        private void comboBoxTests_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadMethods();
        }

        // Смена эксперта для первого метода - смена результатов
        private void comboBoxExperts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_Method1();
        }

        // Загрузка экспертов в таблицу (кто прошел, кто не прошел оценивание)
        private async void LoadExperts(int index)
        {
            label5.Visible = false;
            comboBoxExperts.Visible = false;
            dataGridViewExperts.Rows.Clear();
            dataGridViewExperts.Visible = true;

            // Загружаем список экспертов и соответствующий значок в таблицу
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    // Получаем Id выведенной в Combobox проблемы
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("Select Id from Problems where ProblemName=N'" + comboBoxProblems.Text + "';", connection);
                    int IdProblem = (int)command.ExecuteScalar();
                    string textCommand1 = "", textCommand2 = "";
                    switch(index)
                    {
                        // Метод парных сравнений
                        case 0:
                            textCommand1 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest1 = 1";
                            textCommand2 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest1 = 0" +
                        " or ExpertProblems.StatusTest1 = 2";
                            break;

                        // Метод взвешенных экспертных оценок
                        case 1:
                            textCommand1 = "Select Experts.FIOExpert from Experts" +
                       " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                       " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest2 = 1";
                            textCommand2 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest2 = 0" +
                        " or ExpertProblems.StatusTest2 = 2";
                            break;

                        // Метод предпочтения
                        case 2:
                            textCommand1 = "Select Experts.FIOExpert from Experts" +
                       " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                       " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest3 = 1";
                            textCommand2 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest3 = 0" +
                        " or ExpertProblems.StatusTest3 = 2";
                            break;

                        // Метод ранга
                        case 3:
                            textCommand1 = "Select Experts.FIOExpert from Experts" +
                       " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                       " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest4 = 1";
                            textCommand2 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest4 = 0" +
                        " or ExpertProblems.StatusTest4 = 2";
                            break;

                        // Метод полного попарного сравнения
                        case 4:
                            textCommand1 = "Select Experts.FIOExpert from Experts" +
                       " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                       " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest5 = 1";
                            textCommand2 = "Select Experts.FIOExpert from Experts" +
                        " join ExpertProblems on ExpertProblems.IdExpert = Experts.Id" +
                        " where ExpertProblems.IdProblem = " + IdProblem.ToString() + " and ExpertProblems.StatusTest5 = 0" +
                        " or ExpertProblems.StatusTest5 = 2";
                            break;
                    }
                    // Загрузка экспертов, которые прошли оценивание т.е. статус 1
                    SqlCommand command1 = new SqlCommand(textCommand1, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridViewExperts.Rows.Add();
                            dataGridViewExperts.Rows[i].Cells[0].Value = "✓";
                            dataGridViewExperts.Rows[i].Cells[1].Value = reader.GetString(0);
                            i++;
                        }
                    }
                    reader.Close();

                    // Загрузка экспертов, которые не прошли оценивание т.е статус 0, либо 2
                    SqlCommand command2 = new SqlCommand(textCommand2, connection);
                    reader = command2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridViewExperts.Rows.Add();
                            dataGridViewExperts.Rows[i].Cells[0].Value = "X";
                            dataGridViewExperts.Rows[i].Cells[1].Value = reader.GetString(0);
                            i++;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Смена проблемы, смена альтернатив к ней, смена результатов
        private async void comboBoxProblems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Загружаем альтернативы к выбранной проблеме
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
                    LoadMethods();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
