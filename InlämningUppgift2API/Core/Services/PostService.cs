using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Data;
using InlämningUppgift2API.Data.DTOs.PostDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;

namespace InlämningUppgift2API.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _repo;
        private readonly AppDbContext _context;

        public PostService(IPostRepo repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        private static List<GetPostDTO> Map(List<Post> posts)
        {
            return posts.Select(p => new GetPostDTO
            {
                PostId = p.PostId,
                Title = p.Title,
                Text = p.Text,
                CategoryId = p.CategoryId,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public int CreatePost(CreatePostDTO dto)
        {

            var ExistUser = _context.Users.Any(u => u.UserId == dto.UserId);
            if (!ExistUser) return 0;
            var ExistCategory = _context.Categories.Any(c => c.CategoryId == dto.CategoryId);
            if (!ExistCategory) return 0;

            var post = new Post
            {
                Title = dto.Title,
                Text = dto.Text,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow

            };
             return _repo.Add(post);
        }
        public bool UpdatePost(int postId, UpdatePostDTO dto)
        {
            var post = _repo.GetById(postId);
            if (post == null) return false;
            if (post.UserId != dto.UserId) return false;

            post.Title = dto.Title;
            post.Text = dto.Text;

            _repo.Update();
            return true;
        }
        public bool DeletePost(int postId, int userId)
        {
            var post = _repo.GetById( postId);
            if (post == null) return false;
            if (post.UserId != userId) return false;

           _repo.Delete(post);
            return true;
        }

        public List<GetPostDTO> GetAllPosts()
        {
            return Map  (_repo.GetAll());
        }

        public List<GetPostDTO> GetPostByCategory(int categoryId)
        {
            return Map( _repo.GetByCateGory(categoryId));
        }

        public List<GetPostDTO> GetPostById(int userId)
        {
            return Map( _repo.GetByUser(userId));
        }

        public List<GetPostDTO> SearchPosts(string text)
        {
            return Map( _repo.Search(text));
        }

      
    }
}
