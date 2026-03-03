using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Data.DTOs.CommentsDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Core.Services
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepo _repo;
        private readonly IUserRepo _userRepo;
        private readonly IPostRepo _postRepo;

        public CommentService(ICommentRepo repo, IUserRepo userRepo, IPostRepo postRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _postRepo = postRepo;
        }




        public int CreateComment(CreateCommentDTO dto)
        {
            if (! _userRepo.UserExistById(dto.UserId))
                return 0;
            var post = _postRepo.GetById(dto.PostId);
            if (post == null)
                return 0;
            if (post.UserId == dto.UserId)
                return -1;


            var newComment = new Comment
            {

                Text = dto.Text,
                UserId = dto.UserId,
                PostId = dto.PostId,
                CreatedAt = DateTime.UtcNow
            };
       
            return _repo.Add(newComment);
        }

        public bool UpdateComment(int commentId, UpadateCommentDTO dto)
        {
            var comment = _repo.GetById(commentId);
            if (comment == null) return false;
            if (comment.UserId != dto.UserID) return false;
            comment.Text = dto.Text;
       
            _repo.Update();
            return true;
        }

        public bool DeleteComment(int commentId, int userId)
        {
            var comment = _repo.GetById(commentId);
            if (comment == null) return false;
            if (comment.UserId != userId) return false;

            _repo.Delete(comment);
            return true;
        }

        public List<GetCommentOfPostDTO> GetCommentsByPostId(int postId)
        {
           return Map(_repo.GetByPostId(postId));
        }

        public List<GetCommentOfPostDTO> GetCommentsByUserId(int userId)
        {
           return Map(_repo.GetByUserId(userId));
        }


        private static List<GetCommentOfPostDTO> Map(List<Comment> comments)
        {
            return comments.Select(c => new GetCommentOfPostDTO
            {
                CommentId = c.CommentId,
                PostId = c.PostId,
                Tetxt = c.Text,
                UserId = c.UserId,
                CreatedAt = c.CreatedAt
            }).ToList();
        }
    }
}
