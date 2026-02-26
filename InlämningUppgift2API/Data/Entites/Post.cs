using System.ComponentModel.DataAnnotations;

namespace InlämningUppgift2API.Data.Entites
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; } 


        public User User { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; } = new();

     
    }
}
