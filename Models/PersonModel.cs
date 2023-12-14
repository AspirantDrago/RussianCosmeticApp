namespace RussianCosmeticApp.Models
{
    class PersonModel
    {
        protected string _name;
        protected string _surname;
        protected string _patronymic;

        public string Name { 
            get 
            { 
                return _name;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
        }

        public PersonModel(string name, string surname, string patronymic)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
        }

        public override string ToString()
        {
            return $"{_surname} {_name} {_patronymic}";
        }
    }
}
