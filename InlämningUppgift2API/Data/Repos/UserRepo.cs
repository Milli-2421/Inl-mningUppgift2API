using InlämningUppgift2API.Data;
using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Data.Repos
{
    public class UserRepo : IUserRepo
    {

        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
           _context.Users.Remove(user);
            _context.SaveChanges(); 
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);    
        }

        public User? GetById(int id)
        {
          return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

    

        public bool UserExistById(int id)
        {
            return _context.Users.Any(u => u.UserId == id); 
        }

        public bool UserExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);   
        }
    }
}

