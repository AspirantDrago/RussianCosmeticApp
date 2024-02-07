using System;
using System.Collections.Generic;
using RussianCosmeticApp.Models;

namespace RussianCosmeticApp.Models
{
    /// <summary>
    /// Класс модели данных для заказа
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        protected int _id;
        /// <summary>
        /// Дата и время создания заказа
        /// </summary>
        protected DateTime _dataCreate;
        /// <summary>
        /// Стаус заказа
        /// </summary>
        protected StatusModel _status;
        /// <summary>
        /// Длительность заказа
        /// </summary>
        /// <remarks>
        /// Может быть <see langword="null" />, если длительность неизвестна
        /// </remarks>
        protected float? _duration;
        // TODO protected ClientModel _client;        
        /// <summary>
        /// Удален ли заказ
        /// </summary>
        protected bool _removed;
        /// <summary>
        /// Множество услуг в заказе
        /// </summary>
        protected HashSet<ServiceModel> _services;

        /// <summary>
        /// Возвращает суммарную длительность заказа
        /// </summary>
        /// <value>
        /// Суммарная длительность заказа, часы
        /// </value>
        public float duration
        {
            get
            {
                if (_duration == null)
                {
                    float result = 0;
                    foreach (ServiceModel service in _services)
                    {
                        result += service.duration;
                    }
                    return result;
                }
                return (float)_duration;
            }
        }

        /// <summary>
        /// Возвращает суммарную стоимость заказа
        /// </summary>
        /// <value>
        /// Суммарная стоимость заказа, рубли
        /// </value>
        public decimal price
        {
            get
            {
                decimal result = 0;
                foreach (ServiceModel service in _services)
                {
                    result += service.price;
                }
                return result;
            }
        }

        /// <summary>
        /// Конструктор объекта класса <see cref="OrderModel"/>
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <param name="dataCreate">Дата и время создания заказа</param>
        /// <param name="status">Стаус заказа</param>
        /// <param name="duration">Длительность заказа. <see langword="null"/> если длительность неизвестна</param>
        /// <param name="removed">Удален ли заказ</param>
        public OrderModel(
                int id,
                DateTime dataCreate,
                StatusModel status,
                float? duration,
                // ClientModel client,
                bool removed = false
            )
        {
            _id = id;
            _dataCreate = dataCreate;
            _status = status;
            _duration = duration;
            // _client = client;
            _removed = removed;

            _services = new HashSet<ServiceModel>();
        }

        /// <summary>
        /// Добавляет услугу в заказ
        /// </summary>
        /// <param name="service">Объект модели услуги</param>
        public void AddService(ServiceModel service)
        {
            _services.Add(service);
        }

        /// <summary>
        /// Удаляет услугу из заказа
        /// </summary>
        /// <param name="service">Объект модели услуги</param>
        public void RemoveService(ServiceModel service)
        {
            _services.Remove(service);
        }
    }
}
