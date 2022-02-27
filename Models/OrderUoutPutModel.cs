namespace _02_API.Models
{
    public class OrderUoutPutModel
    {
        public OrderUoutPutModel(int id, DateTime created, int antalProduct, string status)
        {
            Id = id;
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
        }

        public OrderUoutPutModel(DateTime created, int antalProduct, string status, ProductModel productModel)
        {
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
        }

        public OrderUoutPutModel(DateTime created, int antalProduct, string status, OrderUserUotPutModel user, ProductModel product)
        {
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
            User = user;
            Product = product;
        }





        public OrderUoutPutModel(int id, DateTime created, int antalProduct, string status, OrderUserUotPutModel user, ProductModel product)
        {
            Id = id;
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
            User = user;
            Product = product;
        }


        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int AntalProduct { get; set; }
        public string Status { get; set; }
        public ProductModel Product { get; set; }
        public OrderUserUotPutModel User { get; set; }


    }
}
