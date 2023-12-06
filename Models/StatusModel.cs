namespace RussianCosmeticApp.Models
{
    public class StatusModel
    {
        protected int _id;
        protected string _title;

        public StatusModel(
                int id,
                string title
            )
        {
            _id = id;
            _title = title;
        }

        public override string ToString()
        {
            return _title;
        }
    }
}
