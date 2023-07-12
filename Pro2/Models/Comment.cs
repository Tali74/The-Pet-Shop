using System.ComponentModel.DataAnnotations;

namespace Pro2.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
