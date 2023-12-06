namespace RussianCosmeticApp.Models
{
    public class ServiceModel
    {
        protected int _id;
        protected string _title;
        protected decimal _price;
        protected float _duration;
        protected double _std;

        public string title
        {
            get { return _title; }
        }

        public decimal price
        {
            get { return _price; }
        }

        public float duration
        {
            get { return _duration; }
        }

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

        public override string ToString()
        {
            return _title;
        }
    }
}
