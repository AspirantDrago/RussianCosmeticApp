using System;
using System.Security.Cryptography;
using System.Text;

namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Абстрактный класс модели данных для абстрактного клиента
    /// </summary>
    abstract class AbsClientModel
    {
        /// <summary>
        /// ID клиента
        /// </summary>
        protected int? _id;
        /// <summary>
        /// Адрес электронной почты клиента
        /// </summary>
        protected string _email;
        /// <summary>
        /// Хэш пароля клиента
        /// </summary>
        protected string _password;
        /// <summary>
        /// Статический объект класса <see cref="System.Security.Cryptography.HashAlgorithm"/> для хэширования паролей
        /// </summary>
        protected static HashAlgorithm hash = SHA256.Create();

        /// <summary>
        /// Возвращает адрес электронной почты клиента
        /// </summary>
        /// <value>
        /// Адрес электронной почты клиента
        /// </value>
        public string Email
        {
            get { return _email; }
        }

        /// <summary>
        /// Конструктор класса <see cref="AbsClientModel"/>
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <param name="email">Адрес электронной почты клиента</param>
        /// <param name="password">Хэш пароля клиента</param>
        public AbsClientModel(
            int? id,
            string email,
            string password
            )
        {
            _id = id;
            _email = email;
            _password = password;
        }

        /// <summary>
        /// Конвертирует объект в строку
        /// </summary>
        /// <returns>
        /// <see cref="System.String" /> - строковое представление объекта
        /// </returns>
        public abstract override string ToString();

        /// <summary>
        /// Возвращает информацию о клиенте в виде сниппета
        /// </summary>
        /// <returns>
        /// Информация о клиенте в формате сниппета
        /// </returns>
        public abstract string GetInfo();

        /// <summary>
        /// Вычисляет хэш пароля по алгоритму, заданному в поле <see cref="hash"/>
        /// </summary>
        /// <param name="password">Оригинальный пароль клиента</param>
        /// <returns>Хэш пароля клиента</returns>
        public static string GetHashPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            bytes = hash.ComputeHash(bytes);
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
