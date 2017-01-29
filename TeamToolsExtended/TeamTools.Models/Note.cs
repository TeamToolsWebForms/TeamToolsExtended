using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
