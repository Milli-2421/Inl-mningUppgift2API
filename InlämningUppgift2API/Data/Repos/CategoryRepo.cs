using InlämningUppgift2API.Data;
using InlämningUppgift2API.Data.DTOs.CategoryDTOs;
using InlämningUppgift2API.Data.Entites;
using InlämningUppgift2API.Data.interfaces;
using InlämningUppgift2API.Data.Repos;
using Microsoft.EntityFrameworkCore;

namespace InlämningUppgift2API.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Category category)
        {
           _context.Categories.Add(category);   
            _context.SaveChanges();
                return category.CategoryId; 
        }

        public bool ExistByName(string name)
        {
            return _context.Categories.Any(c => c.CategoryName == name);    
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}


