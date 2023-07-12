using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro2.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string? AnimalName { get; set;}
        [Range(0, 150)]
        [Required(ErrorMessage = "Please enter the age.")]
        public int? AnimalAge { get; set; }
        [Required(ErrorMessage = "Please enter a picture path.")]
        public string? PicturePath { get; set; }
        [Required(ErrorMessage = "Please enter the description.")]
        public string? Description { get;set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        [NotMapped]
        public IFormFile? PictureFile { get;set; }
    }
}
