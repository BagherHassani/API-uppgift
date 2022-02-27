using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_API.Models.Entity
{
    public class OrderEntity
    {
     

        public OrderEntity(int antalProduct, DateTime created, string status)
        {
            AntalProduct = antalProduct;
            Created = created;
            Status = status;
            
        }

        public OrderEntity(int id, DateTime created, int antalProduct, int productId, int userId, string status)
        {
            Id = id;
            Created = created;
            AntalProduct = antalProduct;
            ProductId = productId;
            UserId = userId;
            Status = status;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int AntalProduct { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }

        public ProductEntity Products { get; set; }
        public UserEntity Users { get; set; }


    }
}
