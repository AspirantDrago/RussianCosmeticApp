using System.Collections.Generic;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.db;
using MySql.Data.MySqlClient;

namespace RussianCosmeticApp.db
{
    /// <summary>
    /// Класс модели данных для статуса заказа с привязкой к базе данных
    /// </summary>
    /// <seealso cref="RussianCosmeticApp.Models.StatusModel" />
    public class StatusDB : StatusModel
    {
        /// <summary>
        /// Конструктор класса <see cref="StatusDB"/>
        /// </summary>
        /// <param name="id">ID статуса заказа</param>
        /// <param name="title">Название статуса заказа</param>
        public StatusDB(
            int id,
            string title
        ) : base(id, title) {

        }

        /// <summary>
        /// Возвращает все статусы заказа из базы данных
        /// </summary>
        /// <returns>
        /// Список всех статусов заказа из базы данных
        /// </returns>
        public static List<StatusModel> GetAll()
        {
            List<StatusModel> statuses = new List<StatusModel>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT `status_id`, `status_title` FROM `Statuses`";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        statuses.Add(new StatusModel(
                                id: reader.GetInt32(0),
                                title: reader.GetString(1)
                            ));
                    }
                }
            }
            return statuses;
        }

        /// <summary>
        /// Поиск статуса заказа по ID статуса заказа
        /// </summary>
        /// <param name="id">ID статуса заказа</param>
        /// <returns>
        /// Объект статуса заказа с заданным ID.
        /// Если статус заказа не найден, то возвращается <see langword="null"/>
        /// </returns>
        public static StatusModel GetByID(int id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"SELECT `status_id`, `status_title` FROM `Statuses` WHERE `status_id` = {id}";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        return new StatusModel(
                            id: reader.GetInt32(0),
                            title: reader.GetString(1)
                        );
                    }
                }
                return null;
            }
        }
    }
}
