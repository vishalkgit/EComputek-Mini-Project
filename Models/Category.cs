using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComputek.Models
{

    [Table("Category")]
    public class Category
    {
        

        [Key]
        public int categoryid { get; set; }
        [Required]
        public string? name { get; set; }
    }
}
