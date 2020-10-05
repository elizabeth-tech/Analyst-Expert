using System;
using System.IO;
using System.Windows.Forms;

namespace MyProject1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG == false
            string dbPathMyDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbPath = Path.Combine(dbPathMyDocs, "LocalData Analyst&Experts");
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
#endif
            Data.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeneralLogin());
        }
    }
}
