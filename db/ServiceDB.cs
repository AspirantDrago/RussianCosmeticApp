using System.Collections.Generic;
using RussianCosmeticApp.Models;
using MySql.Data.MySqlClient;

namespace RussianCosmeticApp.db
{
    public class ServiceDB : ServiceModel
    {
        public ServiceDB(
            int id,
            string title,
            decimal price,
            float duration,
            double std = 0.0
        ) : base(id, title, price, duration, std) {

        }

        public static List<ServiceModel> GetAll()
        {
            List<ServiceModel> services = new List<ServiceModel>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT `service_id`, `service_title`, `price`, `duration`, `std` FROM `Services`";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        services.Add(new ServiceDB(
                                id: reader.GetInt32(0),
                                title: reader.GetString(1),
                                price: reader.GetDecimal(2),
                                duration: reader.GetFloat(3),
                                std: reader.GetDouble(4)
                            ));
                    }
                }
            }
            return services;
        }
    }
}
