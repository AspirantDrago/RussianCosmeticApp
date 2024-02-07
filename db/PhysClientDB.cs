using System.Collections.Generic;
using RussianCosmeticApp.Models;
using MySql.Data.MySqlClient;
using System;

namespace RussianCosmeticApp.db
{
    /// <summary>
    /// Класс модели данных для клиента - физического лица с привязкой к базе данных
    /// </summary>
    /// <seealso cref="RussianCosmeticApp.Models.PhysClientModel" />
    class PhysClientDB : PhysClientModel
    {
        /// <summary>
        /// Конструктор класса <see cref="PhysClientDB"/>
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <param name="email">Адрес электронной почты клиента</param>
        /// <param name="password">Хэш пароля клиента</param>
        /// <param name="name">Имя клиента</param>
        /// <param name="surname">Фамилия клиента</param>
        /// <param name="patronymic">Отчество клиента</param>
        /// <param name="birthday">Дата рождения клиента</param>
        /// <param name="passportSeria">Серия паспорта клиента (4 цифры)</param>
        /// <param name="passportNumber">Номер паспорта клиента (6 цифр)</param>
        /// <param name="phone">Номер телефона клиента</param>
        public PhysClientDB(
            int? id,
            string email,
            string password,
            string name,
            string surname,
            string patronymic,
            System.DateTime birthday,
            int passportSeria,
            int passportNumber,
            string phone
            ) : base(id, email, password, name, surname, patronymic, birthday, passportSeria, passportNumber, phone)
        {

        }

        /// <summary>
        /// Получение всех клиентов - физических лиц из базы данных
        /// </summary>
        /// <returns>
        /// Список всех клиентов - физических лиц
        /// </returns>
        public static List<PhysClientModel> GetAll()
        {
            List<PhysClientModel> clients = new List<PhysClientModel>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = @"
                SELECT `clients_phys`.`client_id` AS `client_id`, `email`, `password`,
                `name`, `surname`, `patronymic`, `birthday`, `passport`, `phone`
                FROM `clients_phys` 
                INNER JOIN `clients` 
                    ON `clients_phys`.`client_id` = `clients`.`client_id`
                WHERE NOT `clients`.`removed`
                ORDER BY `name`, `surname`, `patronymic`";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clients.Add(new PhysClientDB(
                                id: reader.GetInt32(0),
                                email: reader.GetString(1),
                                password: reader.GetString(2),
                                name: reader.GetString(3),
                                surname: reader.GetString(4),
                                patronymic: reader.GetString(5),
                                birthday: reader.GetDateTime(6),
                                passportSeria: System.Convert.ToInt32(reader.GetString(7).Substring(0, 4)),
                                passportNumber: System.Convert.ToInt32(reader.GetString(7).Substring(4)),
                                phone: reader.GetString(8)
                            ));
                    }
                }
            }
            return clients;
        }

        /// <summary>
        /// Сохранение клиента в базе данных (добавление или обновление)
        /// </summary>
        public void Save() 
        { 
            if (_id == null)
            {
                Insert();
            }
            else
            {
                Update();
            }
        }

        /// <summary>
        /// Добавление клиента в базу данных
        /// </summary>
        /// <exception cref="System.Exception">Пользователь не был добавлен</exception>
        protected void Insert()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlTransaction transaction = conn.BeginTransaction();
            try
            {
                MySqlCommand commandAddClinet = conn.CreateCommand();
                commandAddClinet.CommandText = @"
                    INSERT INTO `clients` 
                    (`email`, `password`, `is_ur`, `removed`)
                    VALUES
                    (@mail, @password, 0, 0);
                ";
                commandAddClinet.Parameters.AddWithValue("@mail", Email);
                commandAddClinet.Parameters.AddWithValue("@password", _password);
                if (commandAddClinet.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Пользователь не был добавлен");
                }
                _id = (int?)commandAddClinet.LastInsertedId;

                MySqlCommand commandAddPhysClinet = conn.CreateCommand();
                commandAddPhysClinet.CommandText = @"
                    INSERT INTO `clients_phys`
                    (`client_id`, `name`, `surname`, `patronymic`, `birthday`, `passport`, `phone`)
                    VALUES
                    (@id, @name, @surname, @patronymic, @birthday, @passport, @phone)
                ";
                commandAddPhysClinet.Parameters.AddWithValue("@id", _id);
                commandAddPhysClinet.Parameters.AddWithValue("@name", Name);
                commandAddPhysClinet.Parameters.AddWithValue("@surname", Surname);
                commandAddPhysClinet.Parameters.AddWithValue("@patronymic", Patronymic);
                commandAddPhysClinet.Parameters.AddWithValue("@birthday", Birthday);
                commandAddPhysClinet.Parameters.AddWithValue("@passport", _passport);
                commandAddPhysClinet.Parameters.AddWithValue("@phone", _phone);
                commandAddPhysClinet.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Изменение данных клиента в базе данных
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Данный метод не реализован
        /// </exception>
        protected void Update()
        {
            throw new NotImplementedException();
        }
    }
}
