using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComputek.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        
        public int Productid { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
        [Required]
        public int Price {  get; set; }    

        [Required]
        public int StockQuantity { get; set; }

        
        public string? Imageurl { get; set; }

        [Required]
        public int categoryid { get; set; }

        [NotMapped]
        public string? name { get; set; }

    }
}
