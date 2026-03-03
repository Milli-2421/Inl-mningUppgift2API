using InlämningUppgift2API.Data.DTOs.CategoryDTOs;

namespace InlämningUppgift2API.Core.Inteface
{
    public interface ICategoryService
    {


        int CreateCategory(CreateCategoryDTO dto);
        List<GetCategoryDTO> GetCategories();
    }
}
