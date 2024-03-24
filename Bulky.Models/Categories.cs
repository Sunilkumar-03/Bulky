using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Name lenght should be less then 100")]
        public string Name { get; set; }
        [Range(1,100, ErrorMessage ="Order should be in between 1-100")]
        public int CategoryOrder { get; set; }
    }
}
