using InlämningUppgift2API.Data.DTOs.PostDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly AppDbContext _context;

        public PostRepo(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post post)
        {
            _context.Posts.Add(post);
             _context.SaveChanges();
            return post.PostId;
        }
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();            
        }
        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public List<Post> GetByCateGory(int id)
        {
            return _context.Posts.Where(p => p.CategoryId == id).ToList();
        }
        

        public Post? GetById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.PostId == id);

        }

        public List<Post> GetByUser(int id)
        {
            return _context.Posts.Where(p => p.UserId == id).ToList();
        }

        public List<Post> Search(string text)
        {
           return _context.Posts.Where(p => p.Title.Contains(text) || p.Text.Contains(text)).ToList();
        }

        public void Update()
        {_context.SaveChanges();
        }
    }
}


