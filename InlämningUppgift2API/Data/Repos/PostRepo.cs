using InlämningUppgift2API.Data.DTOs.PostDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;

namespace InlämningUppgift2API.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly AppDbContext _context;

        public PostRepo(AppDbContext context)
        {
            _context = context;
        }

        public int CreatePost(CreatePostDTO dto)
        {
            var ExistUser = _context.Users.Any(u => u.UserId == dto.UserId);
            if (!ExistUser)return 0;
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
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post.PostId;
        }
                
        public bool UpdatePost(int postId, UpdatePostDTO dto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null) return false;
            if (post.UserId != dto.UserId) return false;

            post.Title = dto.Title;
            post.Text = dto.Text;

            _context.SaveChanges();
            return true;

        }
        public bool DeletePost(int postId, int userId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null) return false;
            if (post.UserId != userId) return false;

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return true;

        }

        public List<GetPostDTO> GetAllPosts()
        {
            return _context.Posts
                .Select(p => new GetPostDTO
            {
                PostId = p.PostId,
                Title = p.Title,
                Text = p.Text,
                UserId = p.UserId,
                Categoryid = p.CategoryId,
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public List<GetPostDTO> SearchPost(string text)
        {
            
            return _context.Posts
                .Where(p => p.Title.Contains(text.ToLower()) || p.Text.Contains(text.ToLower()))
                .Select(p => new GetPostDTO
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Text = p.Text,
                    UserId = p.UserId,
                    Categoryid = p.CategoryId,
                    CreatedAt = p.CreatedAt
                }).ToList();
        }

        public List<GetPostDTO> GetPostsByCategory(int categoryId)
        {
              return _context.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new GetPostDTO
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Text = p.Text,
                    UserId = p.UserId,
                    Categoryid = p.CategoryId,
                    CreatedAt = p.CreatedAt
                }).ToList();
        }

        public List<GetPostDTO> GetPostsByUserId(int userId)
        {
            return _context.Posts
                .Where(p => p.UserId == userId)
                .Select(p => new GetPostDTO
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Text = p.Text,
                    UserId = p.UserId,
                    Categoryid = p.CategoryId,
                    CreatedAt = p.CreatedAt
                }).ToList();
        }
    }
}
