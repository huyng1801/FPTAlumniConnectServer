using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // Example data store (replace with actual service/repository layer)
        private static List<Post> _posts = new List<Post>();
        private static List<User> _users = new List<User>(); // Replace with actual user data
        private static List<Category> _categories = new List<Category>(); // Replace with actual category data

        // GET: api/Post
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var postResponses = _posts.Select(post => new PostResponse
            {
                Id = post.Id,
                Content = post.Content,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                // Populate UserResponse
                User = new UserResponse
                {
                    Id = post.User.Id, // Assuming User is already loaded in the Post entity
                    FirstName = post.User.FirstName,
                    LastName = post.User.LastName,
                    Email = post.User.Email,
                    ProfilePictureUrl = post.User.ProfilePictureUrl,
                    Role = post.User.Role
                },
                // Populate CategoryResponse
                Category = new CategoryResponse
                {
                    Id = post.Category.Id, // Assuming Category is already loaded in the Post entity
                    CategoryName = post.Category.CategoryName,
                    CreatedAt = post.Category.CreatedAt,
                    UpdatedAt = post.Category.UpdatedAt
                }
            }).ToList();

            return Ok(postResponses);
        }

        // GET: api/Post/{id}
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            var postResponse = new PostResponse
            {
                Id = post.Id,
                Content = post.Content,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                // Populate UserResponse
                User = new UserResponse
                {
                    Id = post.User.Id,
                    FirstName = post.User.FirstName,
                    LastName = post.User.LastName,
                    Email = post.User.Email,
                    ProfilePictureUrl = post.User.ProfilePictureUrl,
                    Role = post.User.Role
                },
                // Populate CategoryResponse
                Category = new CategoryResponse
                {
                    Id = post.Category.Id,
                    CategoryName = post.Category.CategoryName,
                    CreatedAt = post.Category.CreatedAt,
                    UpdatedAt = post.Category.UpdatedAt
                }
            };

            return Ok(postResponse);
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostDTO postDto)
        {
            if (postDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var user = _users.FirstOrDefault(u => u.Id == postDto.UserId);
            var category = _categories.FirstOrDefault(c => c.Id == postDto.CategoryId);

            if (user == null || category == null)
            {
                return BadRequest("Invalid User or Category.");
            }

            var newPost = new Post
            {
                Id = _posts.Count + 1,  // Simulate auto-increment
                CategoryId = postDto.CategoryId,
                UserId = postDto.UserId,
                Content = postDto.Content,
                Status = postDto.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                User = user,
                Category = category
            };

            _posts.Add(newPost);

            var response = new PostResponse
            {
                Id = newPost.Id,
                Content = newPost.Content,
                Status = newPost.Status,
                CreatedAt = newPost.CreatedAt,
                UpdatedAt = newPost.UpdatedAt,
                UserId = newPost.UserId,
                // Populate UserResponse
                User = new UserResponse
                {
                    Id = newPost.User.Id,
                    FirstName = newPost.User.FirstName,
                    LastName = newPost.User.LastName,
                    Email = newPost.User.Email,
                    ProfilePictureUrl = newPost.User.ProfilePictureUrl,
                    Role = newPost.User.Role
                },
                // Populate CategoryResponse
                Category = new CategoryResponse
                {
                    Id = newPost.Category.Id,
                    CategoryName = newPost.Category.CategoryName,
                    CreatedAt = newPost.Category.CreatedAt,
                    UpdatedAt = newPost.Category.UpdatedAt
                }
            };

            return Ok(response);
        }

        // PUT: api/Post/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostDTO postDto)
        {
            if (postDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            var category = _categories.FirstOrDefault(c => c.Id == postDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid category.");
            }

            post.Content = postDto.Content;
            post.Status = postDto.Status;
            post.UpdatedAt = DateTime.Now;
            post.CategoryId = postDto.CategoryId;
            post.Category = category; // Update Category reference

            var response = new PostResponse
            {
                Id = post.Id,
                Content = post.Content,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                // Populate UserResponse
                User = new UserResponse
                {
                    Id = post.User.Id,
                    FirstName = post.User.FirstName,
                    LastName = post.User.LastName,
                    Email = post.User.Email,
                    ProfilePictureUrl = post.User.ProfilePictureUrl,
                    Role = post.User.Role
                },
                // Populate CategoryResponse
                Category = new CategoryResponse
                {
                    Id = post.Category.Id,
                    CategoryName = post.Category.CategoryName,
                    CreatedAt = post.Category.CreatedAt,
                    UpdatedAt = post.Category.UpdatedAt
                }
            };

            return Ok(response);
        }

        // DELETE: api/Post/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            _posts.Remove(post);
            return Ok($"Post with Id {id} deleted.");
        }
    }
}
