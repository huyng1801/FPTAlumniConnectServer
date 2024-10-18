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
    public class JobApplicationsController : ControllerBase
    {
        private static List<JobApplication> _jobApplications = new List<JobApplication>();
        private static int _nextId = 1; // Simple ID generator

        // POST: api/jobapplications
        [HttpPost]
        public async Task<ActionResult<JobApplicationResponse>> CreateJobApplication([FromBody] JobApplicationDTO jobApplicationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobApplication = new JobApplication
            {
                Id = _nextId++,
                JobPostId = jobApplicationDto.JobPostId,
                UserId = jobApplicationDto.UserId,
                ApplicantName = jobApplicationDto.ApplicantName,
                CVFileUrl = jobApplicationDto.CVFileUrl,
                CoverLetter = jobApplicationDto.CoverLetter,
                CreatedAt = DateTime.UtcNow,
                IsApproved = false // Default to false on creation
            };

            _jobApplications.Add(jobApplication);

            return CreatedAtAction(nameof(GetJobApplicationById), new { id = jobApplication.Id }, new JobApplicationResponse
            {
                Id = jobApplication.Id,
                JobPostId = jobApplication.JobPostId,
                UserId = jobApplication.UserId,
                ApplicantName = jobApplication.ApplicantName,
                CVFileUrl = jobApplication.CVFileUrl,
                CoverLetter = jobApplication.CoverLetter,
                CreatedAt = jobApplication.CreatedAt,
                IsApproved = jobApplication.IsApproved
            });
        }

        // GET: api/jobapplications/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplicationResponse>> GetJobApplicationById(int id)
        {
            var jobApplication = _jobApplications.FirstOrDefault(a => a.Id == id);

            if (jobApplication == null)
            {
                return NotFound($"Job application with ID {id} not found");
            }

            var response = new JobApplicationResponse
            {
                Id = jobApplication.Id,
                JobPostId = jobApplication.JobPostId,
                UserId = jobApplication.UserId,
                ApplicantName = jobApplication.ApplicantName,
                CVFileUrl = jobApplication.CVFileUrl,
                CoverLetter = jobApplication.CoverLetter,
                CreatedAt = jobApplication.CreatedAt,
                IsApproved = jobApplication.IsApproved
            };

            return Ok(response);
        }

        // GET: api/jobapplications/jobpost/{jobPostId}
        [HttpGet("jobpost/{jobPostId}")]
        public async Task<ActionResult<IEnumerable<JobApplicationResponse>>> GetJobApplicationsByJobPostId(int jobPostId)
        {
            var jobApplications = _jobApplications.Where(a => a.JobPostId == jobPostId).ToList();

            if (!jobApplications.Any())
            {
                return NotFound($"No applications found for Job Post ID {jobPostId}");
            }

            var responses = jobApplications.Select(application => new JobApplicationResponse
            {
                Id = application.Id,
                JobPostId = application.JobPostId,
                UserId = application.UserId,
                ApplicantName = application.ApplicantName,
                CVFileUrl = application.CVFileUrl,
                CoverLetter = application.CoverLetter,
                CreatedAt = application.CreatedAt,
                IsApproved = application.IsApproved
            }).ToList();

            return Ok(responses);
        }

        // GET: api/jobapplications/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<JobApplicationResponse>>> GetJobApplicationsByUserId(int userId)
        {
            var jobApplications = _jobApplications.Where(a => a.UserId == userId).ToList();

            if (!jobApplications.Any())
            {
                return NotFound($"No applications found for User ID {userId}");
            }

            var responses = jobApplications.Select(application => new JobApplicationResponse
            {
                Id = application.Id,
                JobPostId = application.JobPostId,
                UserId = application.UserId,
                ApplicantName = application.ApplicantName,
                CVFileUrl = application.CVFileUrl,
                CoverLetter = application.CoverLetter,
                CreatedAt = application.CreatedAt,
                IsApproved = application.IsApproved
            }).ToList();

            return Ok(responses);
        }
    }
}
