using System.Collections.Generic;
using RussianCosmeticApp.Models;
using MySql.Data.MySqlClient;

namespace RussianCosmeticApp.db
{
    /// <summary>
    /// Класс модели данных для услуги с привязкой к базе данных
    /// </summary>
    /// <seealso cref="RussianCosmeticApp.Models.ServiceModel" />
    public class ServiceDB : ServiceModel
    {
        /// <summary>
        /// Конструктор класса <see cref="ServiceDB"/>
        /// </summary>
        /// <param name="id">ID услуги</param>
        /// <param name="title">Название услуги</param>
        /// <param name="price">Цена услуги, рубли</param>
        /// <param name="duration">Длительность услуги, часы</param>
        /// <param name="std">Стандартное отклонение результата услуги. По умолчанию <c>0.0</c></param>
        public ServiceDB(
            int id,
            string title,
            decimal price,
            float duration,
            double std = 0.0
        ) : base(id, title, price, duration, std) {

        }

        /// <summary>
        /// Возвращает все услуги из базы данных
        /// </summary>
        /// <returns>
        /// Список всех услуг из базы данных
        /// </returns>
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
