namespace _02_API.Models
{
    public class OrderModel
    {
        public OrderModel(DateTime created, int antalProduct, string status)
        {
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
        }

        public OrderModel(DateTime created, int antalProduct, string status, int userId, int productId)
        {
            Created = created;
            AntalProduct = antalProduct;
            Status = status;
            UserId = userId;
            ProductId = productId;
        }

        public DateTime Created { get; set; }
        public int AntalProduct { get; set; }
        public string Status { get; set; }
        public int UserId{ get; set; }
        public int ProductId { get; set; }

    
    }
}
