using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.Entites;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface IUserRepo
    {
       int Register(RegisterUserDTO dto);

       int Login(LoginUserDTO dto);

       int Update(UpdateUserDTO dto, int id);
        bool Delete(int id);

        public List<GettAllUsersDTO> GetAllUsers();
      
    }
}
