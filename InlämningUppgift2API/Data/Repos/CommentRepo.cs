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

        public int Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment.CommentId;
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetAll(int postId)
        {
           return _context.Comments.ToList();   


        }

        public Comment? GetById(int id)
        {
            return _context.Comments.FirstOrDefault(c => c.CommentId == id);
        }

        public List<Comment> GetByPostId(int postId)
        {
           return _context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public List<Comment> GetByUserId(int userId)
        {
            return _context.Comments.Where(c => c.UserId == userId).ToList();
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }
}

