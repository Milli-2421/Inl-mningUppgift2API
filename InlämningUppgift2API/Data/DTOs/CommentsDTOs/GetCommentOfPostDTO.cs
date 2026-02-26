namespace InlämningUppgift2API.Data.DTOs.CommentsDTOs
{
    public class GetCommentOfPostDTO
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Tetxt { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
