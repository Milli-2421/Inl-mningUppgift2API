using InlämningUppgift2API.Data.DTOs.CommentsDTOs;
using InlämningUppgift2API.Data.DTOs.CommentsDTOs;
using InlämningUppgift2API.Data.Entites;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface ICommentRepo
    {
              int Add(Comment comment);         
              Comment? GetById(int id);
              List<Comment> GetAll(int postId);
              List<Comment> GetByPostId(int postId);
              List<Comment> GetByUserId(int userId);
              void Update();
              void Delete(Comment comment);
    }
}

