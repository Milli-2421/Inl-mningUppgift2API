using InlämningUppgift2API.Data.DTOs.CategoryDTOs;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlämningUppgift2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDTO dto)
        {
            var categoryId = _categoryRepo.CreateCategory(dto);
            if (categoryId == null)
            {
                return BadRequest("Category name is required. please enter category name ");
            }
            return Ok(categoryId);
        }

        [HttpGet]
        public IActionResult GetCategory()
        { 
            return Ok(_categoryRepo.GetCategories());
        
        }               
    }
}

