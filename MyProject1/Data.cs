namespace MyProject1
{
    static class Data
    {
        // Строка подключения (физическое расположение локальной базы)
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Test projects\Portfolio\MyProject1\MyProject1\Database.mdf;Integrated Security=True";

        // Данные для окон Эксперта
        public static string nameExpert;

        // Данные для окон Аналитика
        public static string nameProblem;
        public static string nameAlternative;
    }
}
