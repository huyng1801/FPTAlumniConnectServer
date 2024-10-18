using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Example data store (replace with actual service/repository layer)
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, CategoryName = "Technology", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Category { Id = 2, CategoryName = "Business", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        // This is a sample GET method to retrieve all categories using CategoryResponse
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categoryResponses = new List<CategoryResponse>();

            foreach (var category in _categories)
            {
                categoryResponses.Add(new CategoryResponse
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                });
            }

            return Ok(categoryResponses);
        }

        // GET method to retrieve a category by its ID
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            var response = new CategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };

            return Ok(response);
        }

        // Example POST method to create a new category using CategoryDTO and respond with CategoryResponse
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var newCategory = new Category
            {
                Id = _categories.Count + 1,  // Simulating auto-increment Id
                CategoryName = categoryDto.CategoryName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _categories.Add(newCategory);

            var response = new CategoryResponse
            {
                Id = newCategory.Id,
                CategoryName = newCategory.CategoryName,
                CreatedAt = newCategory.CreatedAt,
                UpdatedAt = newCategory.UpdatedAt
            };

            return Ok(response);
        }

        // Example PUT method to update an existing category using CategoryDTO and respond with CategoryResponse
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var existingCategory = _categories.Find(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }

            existingCategory.CategoryName = categoryDto.CategoryName;
            existingCategory.UpdatedAt = DateTime.Now;

            var response = new CategoryResponse
            {
                Id = existingCategory.Id,
                CategoryName = existingCategory.CategoryName,
                CreatedAt = existingCategory.CreatedAt,
                UpdatedAt = existingCategory.UpdatedAt
            };

            return Ok(response);
        }

        // Example DELETE method to delete an existing category
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            _categories.Remove(category);

            return Ok($"Category with Id {id} deleted.");
        }
    }
}
