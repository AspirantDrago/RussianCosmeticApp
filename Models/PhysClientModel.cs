using System;
using System.Linq;

namespace RussianCosmeticApp.Models
{
    class PhysClientModel: AbsClientModel
    {
        protected PersonModel _person;
        protected DateTime _birtday;
        protected string _passport;
        protected string _phone;

        public string Name
        {
            get
            {
                return _person.Name;
            }
        }

        public string Surname
        {
            get
            {
                return _person.Surname;
            }
        }

        public string Patronymic
        {
            get
            {
                return _person.Patronymic;
            }
        }

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

        public int PassportSeria
        {
            get
            {
                return Convert.ToInt32(_passport.Substring(0, 4));
            }
        }

        public int PassportNumber
        {
            get
            {
                return Convert.ToInt32(_passport.Substring(4));
            }
        }

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

        public PhysClientModel(
                int? id,
                string email,
                string password,
                string name,
                string surname,
                string patronymic,
                DateTime birtday,
                int passportSeria,
                int passportNumber,
                string phone
            ): base(id, email, password)
        {
            _person = new PersonModel(name, surname, patronymic);
            Birthday = birtday;
            _passport = passportSeria.ToString().PadLeft(4, '0') +
                passportNumber.ToString().PadLeft(6, '0');
            Phone = phone;
        }

        public override string ToString()
        {
            return _person.ToString();
        }

        public override string GetInfo()
        {
            return 
$@"ФИО: {Surname} {Name} {Patronymic}
e-mail: {Email}
пасспорт: {PassportSeria.ToString().PadLeft(4, '0')} {PassportNumber.ToString().PadLeft(6, '0')}
телефон: {Phone}";
        }
    }
}
