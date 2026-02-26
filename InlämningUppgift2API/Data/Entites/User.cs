using System.ComponentModel.DataAnnotations;

namespace InlämningUppgift2API.Data.Entites
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(60)]
        public string UserName { get; set; }
        [Required]
        [StringLength(80)]
        public string Password { get; set; }
        [Required]
        [StringLength(90)]
        [EmailAddress]
        public string Email { get; set; }

        public List<Post> Posts { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();


    }
}
