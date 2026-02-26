namespace InlämningUppgift2API.Data.DTOs.PostDTOs
{
    public class GetPostDTO
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int Categoryid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
