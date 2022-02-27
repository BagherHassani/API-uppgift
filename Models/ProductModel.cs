namespace _02_API.Models
{
    public class ProductModel
    {
        public ProductModel(string productName, string productType, string articalnumber, string description, string price, string categori)
        {
            ProductName = productName;
            ProductType = productType;
            Articalnumber = articalnumber;
            Description = description;
            Price = price;
            Categori = categori;
        }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string Articalnumber { get; set; }
        public string Description { get; set; }

        public string Price { get; set; }

        public string Categori { get; set; }
    }
}
