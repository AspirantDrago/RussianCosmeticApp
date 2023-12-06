using System.Collections.Generic;
using RussianCosmeticApp.Models;
using RussianCosmeticApp.db;
using MySql.Data.MySqlClient;

namespace RussianCosmeticApp.db
{
    public class StatusDB : StatusModel
    {
        public StatusDB(
            int id,
            string title
        ) : base(id, title) {

        }

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
