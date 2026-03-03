using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.Entites;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface IUserRepo
    {
             void Add(User user);
             User? GetById(int id);
             User? GetByEmail(string email);
             List<User> GetAll();
             void Update();
             void Delete(User user);
             bool UserExistsByEmail(string email);
             bool UserExistById (int id);
    }
}
