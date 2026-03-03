using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Data.DTOs.CategoryDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;
        public CategoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }


        public int CreateCategory(CreateCategoryDTO dto)
        {
           if (string.IsNullOrEmpty(dto.CategoryName)) return 0;

           if (_repo.ExistByName(dto.CategoryName)) return 0;

            var category = new Category
            {
                CategoryName = dto.CategoryName
            };
           
            return _repo.Add(category);

        }

           
        

        public List<GetCategoryDTO> GetCategories()
        {
                return _repo.GetAll()
            .Select(c => new GetCategoryDTO()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }
    }
}




