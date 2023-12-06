using RussianCosmeticApp.Models;
using RussianCosmeticApp;

namespace RussianCosmeticApp.Sources 
{
    public class ServiceSource
    {
        private ServiceModel _service;
        private bool _selected;
        private NewOrderForm _form;

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

        public string title
        {
            get { return _service.title; }
        }

        public decimal price
        {
            get { return _service.price; }
        }

        public float duration
        {
            get { return _service.duration; }
        }

        public ServiceSource(ServiceModel service, NewOrderForm form)
        {
            _selected = false;
            _service = service;
            _form = form;
        }
    }
}
