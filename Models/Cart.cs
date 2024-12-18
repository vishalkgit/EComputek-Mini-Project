using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComputek.Models
{
    [Table("Cart")]
    public class Cart
    {

        [Key]
        public int Cartid { get; set; }


        
        public int Userid { get; set; }

        
        public int Productid { get; set; }

     
        public int Quantity { get; set; }

        [NotMapped]
        public int Price { get; set; }

        [NotMapped]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }

        [NotMapped]
        [Display(Name = "Product")]
        public string? Imageurl { get; set; }

        [NotMapped]
        public int Total { get; set; }

    }
}
