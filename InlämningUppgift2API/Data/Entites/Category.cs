using System.ComponentModel.DataAnnotations;

namespace InlämningUppgift2API.Data.Entites
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(80)]
        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; } = new();
    }
}
