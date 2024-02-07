namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Класс модели данных для статуса заказа
    /// </summary>
    public class StatusModel
    {
        /// <summary>
        /// ID статуса заказа
        /// </summary>
        protected int _id;
        /// <summary>
        /// Название статуса заказа
        /// </summary>
        protected string _title;

        /// <summary>
        /// Конструктор класса <see cref="StatusModel"/>
        /// </summary>
        /// <param name="id">ID статуса заказа</param>
        /// <param name="title">Название статуса заказа</param>
        public StatusModel(
                int id,
                string title
            )
        {
            _id = id;
            _title = title;
        }

        /// <summary>
        /// Конвертирует объект в строку
        /// </summary>
        /// <returns>
        /// Название статуса заказа
        /// </returns>
        public override string ToString()
        {
            return _title;
        }
    }
}
