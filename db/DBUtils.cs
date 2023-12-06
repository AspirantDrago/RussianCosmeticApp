using MySql.Data.MySqlClient;

namespace RussianCosmeticApp.db
{
    /// <summary>
    /// Служебный класс для работы с базой данных
    /// </summary>
    public class DBUtils
    {
        private static MySqlConnection connection = null;
        public static string databaseName = "russian_cosmetic";
        public static string host = "127.0.0.1";
        public static int port = 3306;
        public static string userName = "root";
        public static string userPassword = "root";

        /// <summary>
        /// Статический метод для подключение к базе данных
        /// </summary>
        /// <returns>Объект подключения к базе данных класса SqlConnection</returns>
        public static MySqlConnection GetDBConnection()
        {
            if (connection == null)
            {
                

                connection = new MySqlConnection(
                    $"Server={host};Database={databaseName};port={port};User Id={userName};password={userPassword}"
                );
                
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            return connection;
        }
    }
}
