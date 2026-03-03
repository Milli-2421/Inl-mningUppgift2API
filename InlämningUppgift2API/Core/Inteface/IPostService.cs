using InlämningUppgift2API.Data.DTOs.PostDTOs;

namespace InlämningUppgift2API.Core.Inteface
{
    public interface IPostService
    {
        int CreatePost(CreatePostDTO dto);
        bool UpdatePost(int postId, UpdatePostDTO dto);
        bool DeletePost(int postId, int userId);
        List<GetPostDTO> GetAllPosts();
        List<GetPostDTO> SearchPosts(string text);
        List<GetPostDTO> GetPostByCategory(int categoryId);
        List<GetPostDTO> GetPostById(int userId);

    }

}
