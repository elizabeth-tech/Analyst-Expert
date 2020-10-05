namespace MyProject1
{
    static class Data
    {
        // Строка подключения (физическое расположение локальной базы)
        public static string connectionString;

        // Данные по Экспертам
        public static int IdExpert;
        public static string nameExpert;
        public static string positionExpert;
        public static int competenceExpert;

        public static string selectedProblem;

        // Данные для окон Аналитика
        public static string nameProblem;
        public static string nameAlternative;

        public static string newProblem; // Добавленная проблема
        public static string newExpert; // Добавленный эксперт
    }
}
