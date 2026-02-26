using InlämningUppgift2API.Data.DTOs.CommentsDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;

namespace InlämningUppgift2API.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly AppDbContext _context;
        public CommentRepo(AppDbContext context)
        {
            _context = context;
        }

        public int CreateComment(CreateCommentDTO dto)
        {
            var ExistUsesr = _context.Users.Any(u => u.UserId == dto.UserId);
            if (!ExistUsesr) return 0;

            var ExistPost = _context.Posts.Any(p => p.PostId == dto.PostId);
            if (!ExistPost) return 0;

            var post = _context.Posts.FirstOrDefault(p => p.PostId == dto.PostId);
            if (post == null) return 0;

            if (post.UserId==dto.UserId) return -1;


            var newComment = new Comment
            {

                Text = dto.Text,
                UserId = dto.UserId,
                PostId = dto.PostId,
                CreatedAt = DateTime.UtcNow
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
            return newComment.CommentId;
        }     

        public List<GetCommentOfPostDTO> GetCommentsByPostId(int postId)
        {
           var comments = _context.Comments
                .Where(c => c.PostId == postId).ToList();
            var commentsDTOs = comments
                .Select(c => new GetCommentOfPostDTO
            {
                CommentId = c.CommentId,
                PostId = c.PostId,
                Tetxt = c.Text,
                UserId = c.UserId,
                CreatedAt = c.CreatedAt
            }).ToList();
            return commentsDTOs;
        }


        public List<GetCommentOfPostDTO> GetCommentsByUserId(int userId)
        {
           var comments = _context.Comments
                .Where(c => c.UserId == userId).ToList();
            var commentsDTOs = comments
                .Select(c => new GetCommentOfPostDTO
                {
                    CommentId = c.CommentId,
                    PostId = c.PostId,
                    Tetxt = c.Text,
                    UserId = c.UserId,
                    CreatedAt = c.CreatedAt
                }).ToList();
            return commentsDTOs;
        }

        public bool UpdateComment(int commentId, UpadateCommentDTO dto)
        {
           var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment == null) return false;
            if (comment.UserId != dto.UserID) return false;
            comment.Text = dto.Text;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteComment(int commentId, int userId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment == null) return false;
            if (comment.UserId != userId) return false;
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return true;
        }

    }
}
