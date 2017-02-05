using System.ComponentModel.DataAnnotations;

namespace TeamTools.Logic.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Content { get; set; }

        public bool IsImportant { get; set; }

        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
