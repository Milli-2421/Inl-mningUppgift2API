using InlämningUppgift2API.Controllers;
using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Data.DTOs.PostDTOs;
using InlämningUppgift2API.Data.interfaces;
using InlämningUppgift2API.Data.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlämningUppgift2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreatePost")]
        public IActionResult CreatePost(CreatePostDTO dto)
        {
            var postId = _postService.CreatePost(dto);
            if (postId == 0)
            {
                return BadRequest("User or Category does not exist.");
            }
            return Ok(postId);
        }

        [HttpPut("UpdatePost/{postId}")]
        public IActionResult UpdatePost(int postId, UpdatePostDTO dto)
        {
            var isUpdated = _postService.UpdatePost(postId, dto);
            if (!isUpdated)
            {
                return BadRequest("Post not found or user is not the owner of the post.");
            }
            return Ok("Post updated successfully.");
        }

        [HttpDelete("DeletePost/{postId}")]
        public IActionResult DeletePost(int postId, int userId)
        {
            var isDeleted = _postService.DeletePost(postId, userId);
            if (!isDeleted)
            {
                return BadRequest("Post not found or user is not the owner of the post.");
            }
            return Ok("Post deleted successfully.");

        }

        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("Search")]
        public IActionResult SearchPost(string text)
        {
            var posts = _postService.SearchPosts(text);
            return Ok(posts);
        }

        [HttpGet("GetPostsByCategory/{categoryId}")]
        public IActionResult SearchPostsByCategory(int categoryId)
        {
            var posts = _postService.GetPostByCategory(categoryId);
            return Ok(posts);
        }

        [HttpGet("GetPostsByUserId/{userId}")]
        public IActionResult SearchPostsByUserId(int userId)
        {
            var posts = _postService.GetPostById(userId);
            return Ok(posts);
        }

    }
}

