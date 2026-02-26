using InlämningUppgift2API.Data.DTOs.CommentsDTOs;
using InlämningUppgift2API.Data.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlämningUppgift2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepo;

        public CommentController(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpPost("CreateComment")]
        public IActionResult CreateComment(CreateCommentDTO dto)
        {
            var commentId = _commentRepo.CreateComment(dto);

            if (commentId == -1)
            {
                return BadRequest("You can't comment o your post");
            }

            if (commentId == 0)
            {
                return BadRequest("User or Post does not exist.");
            }
            return Ok(new { commentId });

        }

        [HttpGet("GetCommentsByPostId/{postId}")]
        public IActionResult GetCommentsByPostId(int postId)
        {
            var comments = _commentRepo.GetCommentsByPostId(postId);
            if (comments == null || comments.Count == 0)
            {
                return NotFound("No comments found for this post.");
            }
            return Ok(comments);
        }

        [HttpGet("GetCommentsByUserId/{userId}")]

        public IActionResult GetCommentsByUserId(int userId)
        {
            var comments = _commentRepo.GetCommentsByUserId(userId);
            if (comments == null || comments.Count == 0)
            {
                return NotFound("No comments found for this user.");
            }
            return Ok(comments);
        }


        [HttpPut("UpdateComment/{commentId}")]

        public IActionResult UpdateComment(int commentId, UpadateCommentDTO dto)
        {
            var updated = _commentRepo.UpdateComment(commentId, dto);
            if (!updated)
            {
                return BadRequest("Failed to update comment. Check if the comment exists and the user is correct.");
            }

            return Ok(new { message = "Comment updated successfully", updated });

        }

        [HttpDelete("DeleteComment/{commentId}")]

        public IActionResult DeleteComment(int commentId, int userId)
        {
            var deleted = _commentRepo.DeleteComment(commentId, userId);
            if (!deleted)
            {
                return BadRequest("Failed to delete comment. Check if the comment exists and the user is correct.");
            }
            return Ok(new { message = "Comment deleted successfully", deleted });

        }
    }
}
