using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Core.Services
{
    public class UserService: IUserService
    {

        private readonly IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public int Register(RegisterUserDTO dto)
        {
            if (_repo.UserExistsByEmail(dto.Email)) return 0;

            var user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Password = dto.Password
                };
               _repo.Add(user);
              return user.UserId;
        }

        public int Login(LoginUserDTO dto)
        {
           
            var user = _repo.GetByEmail(dto.Email);
            if (user == null) return 0;
            if(user.Password != dto.Password) return 0;
           
            return user.UserId;
        }

        public bool UpdateUser(int userId, UpdateUserDTO dto)
        {
            var user = _repo.GetById(userId);   
            if (user == null) return false;
           
            user.Email = dto.Email;
            user.Password = dto.Password;

                _repo.Update();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = _repo.GetById(userId);
            if (user == null) return false;
            _repo.Delete(user);
            return true;

        }

        public List<GettAllUsersDTO> GetAllUsers()
        {
            return _repo.GetAll()
                .Select(u => new GettAllUsersDTO
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();
        }   
              
    }
}
