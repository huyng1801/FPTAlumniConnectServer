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
    public class JobPostsController : ControllerBase
    {
        private static List<JobPost> _jobPosts = new List<JobPost>();
        private static int _nextJobPostId = 1; // Simple ID generator

        // POST: api/jobposts
        [HttpPost]
        public async Task<ActionResult<JobPostResponse>> CreateJobPost([FromBody] JobPostDTO jobPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobPost = new JobPost
            {
                JobPostID = _nextJobPostId++,
                JobTitle = jobPostDto.JobTitle,
                Salary = jobPostDto.Salary,
                Location = jobPostDto.Location,
                Experience = jobPostDto.Experience,
                Deadline = jobPostDto.Deadline,
                JobDescription = jobPostDto.JobDescription,
                IsPrivate = jobPostDto.IsPrivate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserID = jobPostDto.UserID
            };

            _jobPosts.Add(jobPost);

            return CreatedAtAction(nameof(GetJobPostById), new { jobPostId = jobPost.JobPostID }, new JobPostResponse
            {
                JobPostID = jobPost.JobPostID,
                JobTitle = jobPost.JobTitle,
                Salary = jobPost.Salary,
                Location = jobPost.Location,
                Experience = jobPost.Experience,
                Deadline = jobPost.Deadline,
                JobDescription = jobPost.JobDescription,
                IsPrivate = jobPost.IsPrivate,
                CreatedAt = jobPost.CreatedAt,
                UpdatedAt = jobPost.UpdatedAt,
                UserID = jobPost.UserID
            });
        }

        // PUT: api/jobposts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobPost(int id, [FromBody] JobPostDTO jobPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobPost = _jobPosts.FirstOrDefault(j => j.JobPostID == id);
            if (jobPost == null)
            {
                return NotFound($"Job post with ID {id} not found");
            }

            // Update fields
            jobPost.JobTitle = jobPostDto.JobTitle;
            jobPost.Salary = jobPostDto.Salary;
            jobPost.Location = jobPostDto.Location;
            jobPost.Experience = jobPostDto.Experience;
            jobPost.Deadline = jobPostDto.Deadline;
            jobPost.JobDescription = jobPostDto.JobDescription;
            jobPost.IsPrivate = jobPostDto.IsPrivate;
            jobPost.UpdatedAt = DateTime.UtcNow; // Update timestamp

            return NoContent();
        }

        // GET: api/jobposts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPostResponse>> GetJobPostById(int id)
        {
            var jobPost = _jobPosts.FirstOrDefault(j => j.JobPostID == id);

            if (jobPost == null)
            {
                return NotFound($"Job post with ID {id} not found");
            }

            var response = new JobPostResponse
            {
                JobPostID = jobPost.JobPostID,
                JobTitle = jobPost.JobTitle,
                Salary = jobPost.Salary,
                Location = jobPost.Location,
                Experience = jobPost.Experience,
                Deadline = jobPost.Deadline,
                JobDescription = jobPost.JobDescription,
                IsPrivate = jobPost.IsPrivate,
                CreatedAt = jobPost.CreatedAt,
                UpdatedAt = jobPost.UpdatedAt,
                UserID = jobPost.UserID
            };

            return Ok(response);
        }

        // GET: api/jobposts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPostResponse>>> GetAllJobPosts()
        {
            var responses = _jobPosts.Select(jobPost => new JobPostResponse
            {
                JobPostID = jobPost.JobPostID,
                JobTitle = jobPost.JobTitle,
                Salary = jobPost.Salary,
                Location = jobPost.Location,
                Experience = jobPost.Experience,
                Deadline = jobPost.Deadline,
                JobDescription = jobPost.JobDescription,
                IsPrivate = jobPost.IsPrivate,
                CreatedAt = jobPost.CreatedAt,
                UpdatedAt = jobPost.UpdatedAt,
                UserID = jobPost.UserID
            }).ToList();

            return Ok(responses);
        }
    }
}
