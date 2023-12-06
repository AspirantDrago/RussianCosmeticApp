using System.Collections.Generic;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.db;
using MySql.Data.MySqlClient;
using System;

namespace RussianCosmeticApp.db
{
    public class OrderDB : OrderModel
    {
        public OrderDB(
           int id,
            DateTime? dataCreate,
            StatusModel status,
            float? duration,
            // ClientModel client,
            bool removed = false
        ) : base(id, (DateTime)dataCreate, status, duration, /* client, */ removed) {

        }

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
