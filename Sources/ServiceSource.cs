using RussianCosmeticApp.Models;
using RussianCosmeticApp;

namespace RussianCosmeticApp.Sources 
{
    /// <summary>
    /// Класс для отображения услуги в форме создания заказа    
    /// </summary>
    public class ServiceSource
    {
        /// <summary>
        /// Объект услуги класса <see cref="ServiceModel"/>
        /// </summary>
        private ServiceModel _service;
        /// <summary>
        /// Выбрана ли услуга
        /// </summary>
        private bool _selected;
        /// <summary>
        /// Ссылка на форму создания заказа
        /// </summary>
        private NewOrderForm _form;

        /// <summary>
        /// Вовзращает или устанавливает значение, выбрана ли услуга <see cref="ServiceSource"/>
        /// </summary>
        /// <value>
        ///   <c>true</c> если услуга выбрана, иначе <c>false</c>.
        /// </value>
        public bool selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (selected)
                {
                    _form.currentOrder.AddService(_service);
                }
                else
                {
                    _form.currentOrder.RemoveService(_service);
                }
                _form.UpdateOrderTotal();
            }
        }

        /// <summary>
        /// Возвращает название услуги <see cref="ServiceSource"/>
        /// </summary>
        /// <value>
        /// Название услуги
        /// </value>
        public string title
        {
            get { return _service.title; }
        }

        /// <summary>
        /// Возвращает цену услуги <see cref="ServiceSource"/>
        /// </summary>
        /// <value>
        /// Цена услуги, рубли
        /// </value>
        public decimal price
        {
            get { return _service.price; }
        }

        /// <summary>
        /// Возвращает длительность услуги <see cref="ServiceSource"/>
        /// </summary>
        /// <value>
        /// Длительность услуги, часы
        /// </value>
        public float duration
        {
            get { return _service.duration; }
        }

        /// <summary>
        /// Конструктор класса <see cref="ServiceSource"/>
        /// </summary>
        /// <param name="service">Объект услуги класса <see cref="ServiceModel"/></param>
        /// <param name="form">Форма создания заказа</param>
        public ServiceSource(ServiceModel service, NewOrderForm form)
        {
            _selected = false;
            _service = service;
            _form = form;
        }
    }
}
