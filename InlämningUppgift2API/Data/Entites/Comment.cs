using System.ComponentModel.DataAnnotations;

namespace InlämningUppgift2API.Data.Entites
{
    public class Comment
    {
        [Key]
         public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
