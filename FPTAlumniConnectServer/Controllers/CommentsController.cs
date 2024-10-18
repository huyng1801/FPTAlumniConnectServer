using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        // In-memory list to hold comments
        private static List<Comment> _comments = new List<Comment>();
        private static int _nextCommentId = 1; // Simple ID generator

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> CreateComment([FromBody] CommentDTO commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = new Comment
            {
                Id = _nextCommentId++,
                PostId = commentDto.PostId,
                UserId = commentDto.UserId,
                Content = commentDto.Content,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _comments.Add(comment);

            return CreatedAtAction(nameof(GetCommentsByPost), new { postId = comment.PostId }, new CommentResponse
            {
                Id = comment.Id,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Content = comment.Content,
                IsDeleted = comment.IsDeleted,
                CreatedAt = comment.CreatedAt
            });
        }

        // DELETE: api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound($"Comment with ID {id} not found");
            }

            comment.IsDeleted = true; // Mark as deleted instead of removing from the list
            return NoContent();
        }

        // GET: api/comments/post/{postId}
        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetCommentsByPost(int postId)
        {
            var comments = _comments
                .Where(c => c.PostId == postId && !c.IsDeleted)
                .Select(c => new CommentResponse
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    UserId = c.UserId,
                    Content = c.Content,
                    IsDeleted = c.IsDeleted,
                    CreatedAt = c.CreatedAt,
                    UserName = "DummyUser" // Replace with actual user data retrieval logic
                })
                .ToList();

            if (!comments.Any())
            {
                return NotFound($"No comments found for post ID {postId}");
            }

            return Ok(comments);
        }

        // GET: api/comments/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetCommentsByUser(int userId)
        {
            var comments = _comments
                .Where(c => c.UserId == userId && !c.IsDeleted)
                .Select(c => new CommentResponse
                {
                    Id = c.Id,
                    PostId = c.PostId,
                    UserId = c.UserId,
                    Content = c.Content,
                    IsDeleted = c.IsDeleted,
                    CreatedAt = c.CreatedAt,
                    UserName = "DummyUser" // Replace with actual user data retrieval logic
                })
                .ToList();

            if (!comments.Any())
            {
                return NotFound($"No comments found for user ID {userId}");
            }

            return Ok(comments);
        }
    }
}
