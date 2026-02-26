using InlämningUppgift2API.Data.DTOs.CategoryDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;

namespace InlämningUppgift2API.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public int CreateCategory(CreateCategoryDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.CategoryId;

        }
        public List<GetCategoryDTO> GetCategories()
        {
            return _context.Categories
                .Select(c => new GetCategoryDTO()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName

                }).ToList();
        }
              
    }
}
