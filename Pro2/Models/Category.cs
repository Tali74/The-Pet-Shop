using System.ComponentModel.DataAnnotations;

namespace Pro2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual IEnumerable<Animal>? Animals { get; set; }

    }
}
