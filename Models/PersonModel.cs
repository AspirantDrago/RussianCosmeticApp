namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Вспомогательный класс модели данных человека
    /// </summary>
    class PersonModel
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        protected string _name;
        /// <summary>
        /// Фамилия человека
        /// </summary>
        protected string _surname;
        /// <summary>
        /// Отчество человека
        /// </summary>
        protected string _patronymic;

        /// <summary>
        /// Возвращает имя человека
        /// </summary>
        /// <value>
        /// Имя человека
        /// </value>
        public string Name { 
            get 
            { 
                return _name;
            }
        }

        /// <summary>
        /// Возвращает фамилию человека
        /// </summary>
        /// <value>
        /// Фамилия человека
        /// </value>
        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        /// <summary>
        /// Возвращает отчество человека
        /// </summary>
        /// <value>
        /// Отчество человека
        /// </value>
        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
        }

        /// <summary>
        /// Конструктор класса <see cref="PersonModel"/>
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="patronymic">Отчество человека</param>
        public PersonModel(string name, string surname, string patronymic)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
        }

        /// <summary>
        /// Конвертирует объект в строку
        /// </summary>
        /// <returns>
        /// <see cref="System.String" /> - строковое представление объекта в формате:
        /// <c>
        /// {Surname} {Name} {Patronymic}
        /// </c>
        /// </returns>
        public override string ToString()
        {
            return $"{_surname} {_name} {_patronymic}";
        }
    }
}
