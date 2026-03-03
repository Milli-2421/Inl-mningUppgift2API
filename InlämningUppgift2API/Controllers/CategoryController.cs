using InlämningUppgift2API.Core.Inteface;
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
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

      

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDTO dto)
        {
            var id = _service.CreateCategory(dto);
            if (id == null)
            {
                return BadRequest("Category name is required. please enter category name ");
            }
            return Ok( new { categoryId = id});
        }

        [HttpGet]
        public IActionResult GetCategory()
        { 
            return Ok (_service.GetCategories());

        }               
    }
}

