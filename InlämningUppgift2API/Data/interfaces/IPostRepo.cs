using InlämningUppgift2API.Data.DTOs.PostDTOs;
using InlämningUppgift2API.Data.Entites;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface IPostRepo
    {
            int Add(Post post);
         
            Post? GetById(int id);
            List<Post> GetAll();
            List<Post> GetByCateGory(int id);
            List<Post> GetByUser(int id);
            List<Post> Search(string text);

            void Update();
            void Delete(Post post);
        }
    
}
