using InlämningUppgift2API.Data;
using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;

namespace InlämningUppgift2API.Data.Repos
{
    public class UserRepo : IUserRepo
    {

        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }


        public int Register(RegisterUserDTO dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;

        }

        public int Login(LoginUserDTO dto)
        {
            var user = _context.Users.FirstOrDefault(u => 
            u.UserName == dto.UserName && u.Password == dto.Password);
            if (user == null)
            {
                return 0;
            }
            return user.UserId;
        }

        public int Update(UpdateUserDTO dto, int id)
        {
            var user = _context.Users.FirstOrDefault(u => 
                            u.UserId == id);
            if (user == null) 
            { 
              return 0;

            }
                user.Email = dto.Email;
                user.Password = dto.Password;
                _context.SaveChanges();
                return user.UserId;    
            
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u =>
                        u.UserId == id);
            if(user == null)
            {  return false; }

            var comments= _context.Comments.Where(c => c.UserId == id).ToList();
            if (comments.Any()) 
            _context.Comments.RemoveRange(comments);


            var posts = _context.Posts.Where(p => p.UserId==id).ToList();
            if (posts.Any())
                _context.Posts.RemoveRange(posts);


            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public List<GettAllUsersDTO> GetAllUsers()
        {
            return _context.Users
                 .Select(u => new GettAllUsersDTO
                 {
                     UserId = u.UserId,
                     UserName = u.UserName,
                     Email = u.Email,
                 }).ToList();
                 
        }
    }
}
