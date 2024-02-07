using System.Collections.Generic;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.db;
using MySql.Data.MySqlClient;
using System;

namespace RussianCosmeticApp.db
{
    /// <summary>
    /// Класс модели данных для заказа с привязкой к базе данных
    /// </summary>
    /// <seealso cref="RussianCosmeticApp.Models.OrderModel" />
    public class OrderDB : OrderModel
    {
        /// <summary>
        /// Конструктор объекта класса <see cref="OrderDB"/>
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <param name="dataCreate">Дата и время создания заказа. Если <see langword="null"/>, то будет установлено текущее время при сохранении в базу данных</param>
        /// <param name="status">Стаус заказа</param>
        /// <param name="duration">Длительность заказа. <see langword="null"/> если длительность неизвестна</param>
        /// <param name="removed">Удален ли заказ</param>
        public OrderDB(
           int id,
            DateTime? dataCreate,
            StatusModel status,
            float? duration,
            // ClientModel client,
            bool removed = false
        ) : base(id, (DateTime)dataCreate, status, duration, /* client, */ removed) {

        }

        /// <summary>
        /// Возвращает следующий ID для нового заказа
        /// </summary>
        /// <returns>Следующий ID для нового заказа</returns>
        public static int GetNewId()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $@"SELECT AUTO_INCREMENT
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_NAME = 'orders'
                AND TABLE_SCHEMA = '{DBUtils.databaseName}'";
            object result = command.ExecuteScalar();
            result = (result == DBNull.Value) ? null : result;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Поиск заказа по ID
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns>
        /// Заказ с заданным ID.
        /// Если заказ не найден, то возвращается <see langword="null"/>
        /// </returns>
        public static OrderModel GetByID(int id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"SELECT `order_id`, `data_create`, `status`, `duration`, `client`, `removed` FROM `Orders` WHERE `order_id` = {id}";
            int orderId, statusId, clientId;
            DateTime dataCreate;
            float duration;
            bool removed;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        orderId = reader.GetInt32(0);
                        dataCreate = reader.GetDateTime(1);
                        statusId = reader.GetInt32(2);
                        duration = reader.GetFloat(3);
                        // clientId = reader.GetInt32(4);
                        removed = reader.GetBoolean(5);
                    }
                }
                else
                {
                    return null;
                }
            }
            return new OrderModel(
                id: orderId,
                dataCreate: dataCreate,
                status: StatusDB.GetByID(statusId),
                duration: duration,
                // TODO client: ClientDB.GetByID(clientId)),
                removed: removed
            ); ;
        }
    }
}
