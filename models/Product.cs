namespace learningprojectserver.models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageurl { get; set; }
        public string category { get; set; }
    }
}
