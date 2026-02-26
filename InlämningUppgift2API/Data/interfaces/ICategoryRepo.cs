using InlämningUppgift2API.Data.DTOs.CategoryDTOs;

namespace InlämningUppgift2API.Data.interfaces
{
    public interface ICategoryRepo
    {
        int CreateCategory(CreateCategoryDTO dto);
        List<GetCategoryDTO> GetCategories();       
    }
}
