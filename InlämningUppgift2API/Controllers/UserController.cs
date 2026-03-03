using InlämningUppgift2API.Core.Inteface;
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
    private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]

        public IActionResult Register(RegisterUserDTO dto)
        {
            var userId = _service.Register(dto);
            if (userId == 0)
            {
                return BadRequest("This Email Adress is aready exist.");
            }
            return Ok(new { userId = userId });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var user = _service.GetAllUsers();
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserDTO dto)
        {
            var userId = _service.Login(dto);

            if (userId == 0)

            { return BadRequest("Invalid user data."); }

            return Ok(new { userId });
        }

        [HttpPut("update/{id}")]

        public IActionResult UpdateUser(UpdateUserDTO dto, int id)
        {
            var updatedUserID = _service.UpdateUser(id, dto);

            if (!updatedUserID )
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
            var deleted = _service.DeleteUser(id);
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
