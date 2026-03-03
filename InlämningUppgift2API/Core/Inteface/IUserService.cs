using InlämningUppgift2API.Data.DTOs.UserDTOs;

namespace InlämningUppgift2API.Core.Inteface
{
    public interface IUserService
    {

         int Register(RegisterUserDTO dto);
        int Login(LoginUserDTO dto);
         bool UpdateUser(int userId, UpdateUserDTO dto);
         bool DeleteUser(int userId);
         List<GettAllUsersDTO> GetAllUsers();        
    }
}
