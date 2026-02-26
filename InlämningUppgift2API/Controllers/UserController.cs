using InlämningUppgift2API.Data.DTOs.UserDTOs;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InlämningUppgift2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]

        public IActionResult Register(RegisterUserDTO dto)
        {
            var newUserId = _repo.Register(dto);
            return Ok(new { userId = newUserId });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var user = _repo.GetAllUsers();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserDTO dto)
        {
            var userId = _repo.Login(dto);

            if (userId == 0)

            { return BadRequest("Invalid user data."); }

            return Ok(new { userId });
        }

        [HttpPut("update/{id}")]

        public IActionResult UpdateUser(UpdateUserDTO dto, int id)
        {
            var updatedUserID = _repo.Update(dto, id);

            if (updatedUserID == 0)
            {
                return NotFound(" User not found.");
            }
            return Ok(new
            {
                userId = updatedUserID,
                message = "Updated Successfully."
            });
        }


        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _repo.Delete(id);
            if (!deleted)
            
                return NotFound("User Not Found");

                return Ok(new
                {
                    message = "Deleted successfully.",
                    userId = id,
                });            
        }

       

    }
}
