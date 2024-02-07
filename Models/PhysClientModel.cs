using System;
using System.Linq;

namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Класс модели данных для клиента - физического лица
    /// </summary>
    /// <seealso cref="RussianCosmeticApp.Models.AbsClientModel" />
    class PhysClientModel : AbsClientModel
    {
        /// <summary>
        /// Модель данных для физического лица
        /// </summary>
        protected PersonModel _person;
        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        protected DateTime _birtday;
        /// <summary>
        /// Паспорт клиента
        /// 10 цифр (серия и номер без пробелов)
        /// </summary>
        protected string _passport;
        /// <summary>
        /// Контактный телефон клиента
        /// </summary>
        protected string _phone;

        /// <summary>
        /// Возвращает имя клиента
        /// </summary>
        /// <value>
        /// Имя клиента
        /// </value>
        public string Name
        {
            get
            {
                return _person.Name;
            }
        }

        /// <summary>
        /// Возвращает фамилию клиента
        /// </summary>
        /// <value>
        /// Фамилия клиента
        /// </value>
        public string Surname
        {
            get
            {
                return _person.Surname;
            }
        }

        /// <summary>
        /// Возвращает отчество клиента
        /// </summary>
        /// <value>
        /// Отчество клиента
        /// </value>
        public string Patronymic
        {
            get
            {
                return _person.Patronymic;
            }
        }

        /// <summary>
        /// Возвращает или задает дату рождения клиента
        /// </summary>
        /// <value>
        /// Дата рождения клиента
        /// </value>
        public DateTime Birthday
        {
            get
            {
                return _birtday;
            }
            protected set
            {
                _birtday = value.Date;
            }
        }

        /// <summary>
        /// Возвращает серию паспорта клиента
        /// </summary>
        /// <value>
        /// Серия паспорта клиента (4 цифры)
        /// </value>
        public int PassportSeria
        {
            get
            {
                return Convert.ToInt32(_passport.Substring(0, 4));
            }
        }

        /// <summary>
        /// Возвращает номер паспорта клиента
        /// </summary>
        /// <value>
        /// Номер паспорта клиента (6 цифр)
        /// </value>
        public int PassportNumber
        {
            get
            {
                return Convert.ToInt32(_passport.Substring(4));
            }
        }

        /// <summary>
        /// Возвращает или задает контактный телефон клиента.
        /// При задании номера телефона удаляются все символы, кроме цифр.
        /// </summary>
        /// <value>
        /// Номер телефона клиента
        /// </value>
        public string Phone
        {
            get
            {
                return _phone;
            }
            private set
            {
                _phone = new String(value.Where(Char.IsDigit).ToArray());
            }
        }

        /// <summary>
        /// Конструктор класса <see cref="PhysClientModel"/>
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
        public PhysClientModel(
                int? id,
                string email,
                string password,
                string name,
                string surname,
                string patronymic,
                DateTime birthday,
                int passportSeria,
                int passportNumber,
                string phone
            ): base(id, email, password)
        {
            _person = new PersonModel(name, surname, patronymic);
            Birthday = birthday;
            _passport = passportSeria.ToString().PadLeft(4, '0') +
                passportNumber.ToString().PadLeft(6, '0');
            Phone = phone;
        }

        /// <summary>
        /// Конвертирует объект в строку
        /// </summary>
        /// <returns>
        /// ФИО клиента в формате:
        /// <c>
        /// {Surname} {Name} {Patronymic}
        /// </c>
        /// </returns>
        public override string ToString()
        {
            return _person.ToString();
        }

        /// <summary>
        /// Возвращает информацию о клиенте в виде сниппета
        /// </summary>
        /// <returns>
        /// Информация о клиенте в формате сниппета:
        /// <code>
        /// ФИО: {Surname} {Name} {Patronymic}
        /// e-mail: {Email}
        /// паспорт: {PassportSeria} {PassportNumber}
        /// телефон: {Phone}
        /// </code>
        /// </returns>
        public override string GetInfo()
        {
            return 
$@"ФИО: {Surname} {Name} {Patronymic}
e-mail: {Email}
паспорт: {PassportSeria.ToString().PadLeft(4, '0')} {PassportNumber.ToString().PadLeft(6, '0')}
телефон: {Phone}";
        }
    }
}
