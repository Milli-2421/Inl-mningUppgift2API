using InlämningUppgift2API.Data.DTOs.CategoryDTOs;
using InlämningUppgift2API.Data.Entites;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface ICategoryRepo
    {
      int Add(Category category);
      List<Category> GetAll();
      bool ExistByName(string name);    
    }
}

