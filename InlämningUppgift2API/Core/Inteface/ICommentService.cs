using InlämningUppgift2API.Data.DTOs.CommentsDTOs;

namespace InlämningUppgift2API.Core.Inteface
{
    public interface ICommentService
    {
        int CreateComment(CreateCommentDTO dto);
        public List<GetCommentOfPostDTO> GetCommentsByPostId(int postId);

        public List<GetCommentOfPostDTO> GetCommentsByUserId(int userId);

        bool UpdateComment(int commentId, UpadateCommentDTO dto);

        bool DeleteComment(int commentId, int userId);

    }
}
