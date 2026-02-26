using InlämningUppgift2API.Data.DTOs.PostDTOs;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface IPostRepo
    {
        int CreatePost(CreatePostDTO dto);
        bool UpdatePost(int postId, UpdatePostDTO dto);

        bool DeletePost(int postId, int userId);
        public List<GetPostDTO> GetAllPosts();
        public List<GetPostDTO> GetPostsByCategory(int categoryId);
        public List<GetPostDTO> GetPostsByUserId(int userId);
        public List<GetPostDTO> SearchPost(string text);










    }
}
