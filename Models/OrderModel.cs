using System;
using System.Collections.Generic;
using RussianCosmeticApp.Models;

namespace RussianCosmeticApp.Models
{
    public class OrderModel
    {
        protected int _id;
        protected DateTime _dataCreate;
        protected StatusModel _status;
        protected float? _duration;
        // TODO protected ClientModel _client;
        protected bool _removed;
        protected HashSet<ServiceModel> _services;

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

        public void AddService(ServiceModel service)
        {
            _services.Add(service);
        }

        public void RemoveService(ServiceModel service)
        {
            _services.Remove(service);
        }
    }
}
