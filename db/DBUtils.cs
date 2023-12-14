﻿using System.Windows.Forms;

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
            while (true) {
                try
                {
                    connection.Open();
                    break;
                }
                catch (MySqlException e)
                {
                    DialogResult result = MessageBox.Show($"Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        System.Environment.Exit(1);
                    }
                }
            }
            return connection;
        }
    }
}
