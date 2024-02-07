namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Класс модели данных для услуги
    /// </summary>
    public class ServiceModel
    {
        /// <summary>
        /// ID услуги
        /// </summary>
        protected int _id;
        /// <summary>
        /// Название услуги
        /// </summary>
        protected string _title;
        /// <summary>
        /// Цена услуги, руб
        /// </summary>
        protected decimal _price;
        /// <summary>
        /// Длительность услуги, часы
        /// </summary>
        protected float _duration;
        /// <summary>
        /// Стандартное отклонение результата услуги
        /// </summary>
        protected double _std;

        /// <summary>
        /// Возвращает название услуги
        /// </summary>
        /// <value>
        /// Название услуги
        /// </value>
        public string title
        {
            get { return _title; }
        }

        /// <summary>
        /// Возвращает цену услуги
        /// </summary>
        /// <value>
        /// Цена услуги, рубли
        /// </value>
        public decimal price
        {
            get { return _price; }
        }

        /// <summary>
        /// Возвращает длительность услуги
        /// </summary>
        /// <value>
        /// Длительность услуги, часы
        /// </value>
        public float duration
        {
            get { return _duration; }
        }

        /// <summary>
        /// Конструктор класса <see cref="ServiceModel"/>
        /// </summary>
        /// <param name="id">ID услуги</param>
        /// <param name="title">Название услуги</param>
        /// <param name="price">Цена услуги, рубли</param>
        /// <param name="duration">Длительность услуги, часы</param>
        /// <param name="std">Стандартное отклонение результата услуги</param>
        public ServiceModel(
                int id,
                string title,
                decimal price,
                float duration,
                double std = 0.0
            )
        {
            _id = id;
            _title = title;
            _price = price;
            _duration = duration;
            _std = std;
        }

        /// <summary>
        /// Конвертирует объект в строку
        /// </summary>
        /// <returns>
        /// Название услуги
        /// </returns>
        public override string ToString()
        {
            return _title;
        }
    }
}
