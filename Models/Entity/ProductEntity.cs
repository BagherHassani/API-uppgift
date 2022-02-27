using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_API.Models.Entity
{
    public class ProductEntity
    {
        public ProductEntity(string prdoductName, string prdoductType, string description, string articalNumber, string price, string categori)
        {
            PrdoductName = prdoductName;
            PrdoductType = prdoductType;
            Description = description;
            ArticalNumber = articalNumber;
            Price = price;
            Categori = categori;
        }

        public ProductEntity(int id, string prdoductName, string prdoductType, string description, string articalNumber, string price, string categori)
        {
            Id = id;
            PrdoductName = prdoductName;
            PrdoductType = prdoductType;
            Description = description;
            ArticalNumber = articalNumber;
            Price = price;
            Categori = categori;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PrdoductName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PrdoductType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ArticalNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Categori { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }

    }
}
