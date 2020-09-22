using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class Expert_Method_PairwiseComparison : Form
    {
        Dictionary<int, List<string>> combinations = new Dictionary<int, List<string>>(); // Структура для комбинаций альтернатив
        Dictionary<int, double> choices = new Dictionary<int, double>(); // Структура для хранения выбора radiobutton для каждого вопроса

        public Expert_Method_PairwiseComparison()
        {
            InitializeComponent();
        }

        // Рекурсивная функция факториала числа
        private int Fact(int num)
        {
            return (num > 1) ? num * Fact(num - 1) : 1;
        }

        // Реализация сочетаний
        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items) // item - объекты, которые перебираются, items - объект перечислений
            {
                if (count == 1) // Count - количество объектов в сочетании
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }
                ++i;
            }
        }

        // Закрытие окна
        private void buttonExpertLoginClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание окна
        private void buttonExpertLoginTurn_Click(object sender, EventArgs e)
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
        private async void Expert_Method_PairwiseComparison_Load(object sender, EventArgs e)
        {
            textBox2.Text = Data.selectedProblem; // Выводим название проблемы, по которой проходим тест

            // Заполнение таблицы альтернативами выбранной проблемы
            using (SqlConnection connection = new SqlConnection(Data.connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("select Alternatives.AlternativeName" +
                        " from Problems" +
                        " join Alternatives on Alternatives.IdProblem = Problems.Id" +
                        " where Problems.Id = (select Problems.Id from Problems" +
                        " where Problems.ProblemName = N'" + textBox2.Text + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    dataGridViewAlternatives.Rows.Clear();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridViewAlternatives.Rows.Add();
                            dataGridViewAlternatives.Rows[i].Cells[0].Value = reader.GetString(0);
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

            // Формула числа сочетаний, определяющая количество вопросов в тесте
            int QuestionLength = Fact(dataGridViewAlternatives.RowCount) / (Fact(dataGridViewAlternatives.RowCount - 2) * 2);
            for (int i = 1; i <= QuestionLength; i++) // Вносим номера вопросов в comboBox
                comboBox1.Items.Add(i);
            comboBox1.Text = comboBox1.Items[0].ToString();
            label6.Text = QuestionLength.ToString();

            // Реализация сочетаний альтернатив
            // Создаем структуру, ключ-значение. Где ключ - номер вопроса, а значение - две сравниваемые альтернативы
            var list = new List<string>();
            for (int i = 0; i < dataGridViewAlternatives.RowCount; i++)
                list.Add(dataGridViewAlternatives.Rows[i].Cells[0].Value.ToString());
            List<string> alternatives = new List<string>();
            foreach (var number in GetPermutations(list, 2))
            {
                foreach (var n in number)
                    alternatives.Add(n);
            }
            int k = 0, c = 1;
            for (int i = 1; i < QuestionLength + 1; i++)
            {
                combinations.Add(i, new List<string> { alternatives[k], alternatives[c] });
                k += 2;
                c += 2;
            }

            // Выводим первое сочетание альтернатив в поля
            textBoxAlter1.Text = combinations[Convert.ToInt16(comboBox1.Text)][0];
            textBoxAlter2.Text = combinations[Convert.ToInt16(comboBox1.Text)][1];

            
        }

        // Сохранение в память выбранных значений Radiobutton
        private void SelectRadioButton()
        {
            // Отображение альтернатив
            textBoxAlter1.Text = combinations[Convert.ToInt16(comboBox1.Text)][0];
            textBoxAlter2.Text = combinations[Convert.ToInt16(comboBox1.Text)][1];
            
            // Если пользователь уже выбирал ответ на этот вопрос
            if (choices.TryGetValue(comboBox1.SelectedIndex, out double value))
            {
                if (value == 1)
                    radioButton1.Checked = true;
                if (value == 0.5)
                    radioButton2.Checked = true;
                if (value == 0)
                    radioButton3.Checked = true;
            }
            else
                radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
        }

        // Переход на предыдущий вопрос
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 1)
            {
                int index = comboBox1.SelectedIndex - 1;
                comboBox1.SelectedIndex = index;
                SelectRadioButton();
            }
        }

        // Переход на следующий вопрос
        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= comboBox1.MaxDropDownItems)
            {                
                int index = comboBox1.SelectedIndex + 1;
                comboBox1.SelectedIndex = index;
                SelectRadioButton();
            }
        }

        // При изменении номера вопроса, выводим нужное сочетание альтернатив
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectRadioButton();
        }

        // Сохранение теста
        private void buttonSaveTest_Click(object sender, EventArgs e)
        {
            int countAlter = dataGridViewAlternatives.RowCount;
            // Формула числа сочетаний, определяющая количество вопросов в тесте
            int QuestionLength = Fact(countAlter) / (Fact(countAlter - 2) * 2);

            if (choices.Count != QuestionLength)
                MessageBox.Show("Невозможно сохранить результаты! Необходимо пройти все вопросы теста!\nВы вправе исправить ответы позже, но сохранение пустых ответов запрещено.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            // Если пользователь заполнил все ответы, то можно сохранить их в файл
            else
            {
                // Заполняем матрицу нулями
                Data.matrix = new double[countAlter, countAlter];
                for (int i = 0; i < countAlter; i++)
                {
                    for (int k = 0; k < countAlter; k++)
                        Data.matrix[i, k] = 0;
                }

                // Заполняем значениями из тестов
                int d = 0, t = 0;
                for (int i = 0; i < countAlter - 1; i++)
                {
                    d++;
                    for (int j = d; j < countAlter; j++)
                    {
                        Data.matrix[i, j] = choices[t];
                        if (choices[t] == 0.5)
                            Data.matrix[j, i] = 0.5;
                        if (choices[t] == 0)
                            Data.matrix[j, i] = 1;
                        t++;
                    }
                }

                // Вывод матрицы в файл
                using (StreamWriter sw = new StreamWriter("Data/Matrix.txt"))
                {
                    for (int i = 0; i < countAlter; i++)
                    {
                        for (int j = 0; j < countAlter; j++)
                            sw.Write("{0}\t", Data.matrix[i, j]);
                        sw.WriteLine();
                    }
                    sw.Close();
                }

                /* Алгоритм парных сравнений по матрице предпочтений */

                // Суммирование оценок по соответствующей строке матрицы предпочтений
                double[] C = new double[countAlter]; // Цена, которая обозначает важность каждой альтернативы
                for (int i = 0; i < countAlter; i++)
                    for (int j = 0; j < countAlter; j++)
                        C[i] += Data.matrix[i, j];
                
                // Находим R - сумму всех цен
                double R = 0;
                for (int i = 0; i < countAlter; i++)
                    R += C[i];

                // Нормирование полученных цен
                double[] V = new double[countAlter];
                for (int i = 0; i < countAlter; i++)
                {
                    V[i] = C[i] / R;
                    //MessageBox.Show(V[i].ToString());
                }
            }
        }

        // Первый вариант
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton1.Checked == true)
            {
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 1;
                else
                    choices.Add(comboBox1.SelectedIndex, 1);
            }
        }

        // Второй вариант
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton2.Checked == true)
            {
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 0.5;
                else
                    choices.Add(comboBox1.SelectedIndex, 0.5);
            }
        }

        // Третий вариант
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Сохранение в словарь значений
            if (radioButton3.Checked == true)
            {
                if (choices.TryGetValue(comboBox1.SelectedIndex, out _))
                    choices[comboBox1.SelectedIndex] = 0;
                else
                    choices.Add(comboBox1.SelectedIndex, 0);
            }
        }
    }
}
