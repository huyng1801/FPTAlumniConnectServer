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
    public class PostReportsController : ControllerBase
    {
        // In-memory list to hold post reports
        private static List<PostReport> _postReports = new List<PostReport>();
        private static int _nextReportId = 1; // Simple ID generator

        // POST: api/postreports
        [HttpPost]
        public async Task<ActionResult<PostReportResponse>> CreatePostReport([FromBody] PostReportDTO reportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = new PostReport
            {
                Id = _nextReportId++,
                PostId = reportDto.PostId,
                UserId = reportDto.UserId
            };

            _postReports.Add(report);

            return CreatedAtAction(nameof(GetReportById), new { postId = report.PostId }, new PostReportResponse
            {
                Id = report.Id,
                PostId = report.PostId,
                UserId = report.UserId,
                UserName = "DummyUser" // Replace with actual user retrieval logic
            });
        }
        // GET: api/postreports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostReportResponse>> GetReportById(int id)
        {
            var report = _postReports.FirstOrDefault(r => r.Id == id);

            if (report == null)
            {
                return NotFound($"Report with ID {id} not found");
            }

            var response = new PostReportResponse
            {
                Id = report.Id,
                PostId = report.PostId,
                UserId = report.UserId,
                UserName = "DummyUser" // Replace with actual user retrieval logic
            };

            return Ok(response);
        }
        // PUT: api/postreports/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostReport(int id, [FromBody] PostReportDTO reportDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = _postReports.FirstOrDefault(r => r.Id == id);
            if (report == null)
            {
                return NotFound($"Report with ID {id} not found");
            }

            report.PostId = reportDto.PostId;
            report.UserId = reportDto.UserId;

            return NoContent();
        }

        // GET: api/postreports/post/{postId}
        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<PostReportResponse>>> GetReportsByPostId(int postId)
        {
            var reports = _postReports
                .Where(r => r.PostId == postId)
                .Select(r => new PostReportResponse
                {
                    Id = r.Id,
                    PostId = r.PostId,
                    UserId = r.UserId,
                    UserName = "DummyUser" // Replace with actual user retrieval logic
                })
                .ToList();

            if (!reports.Any())
            {
                return NotFound($"No reports found for post ID {postId}");
            }

            return Ok(reports);
        }

        // GET: api/postreports/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PostReportResponse>>> GetReportsByUserId(int userId)
        {
            var reports = _postReports
                .Where(r => r.UserId == userId)
                .Select(r => new PostReportResponse
                {
                    Id = r.Id,
                    PostId = r.PostId,
                    UserId = r.UserId,
                    UserName = "DummyUser" // Replace with actual user retrieval logic
                })
                .ToList();

            if (!reports.Any())
            {
                return NotFound($"No reports found for user ID {userId}");
            }

            return Ok(reports);
        }
    }
}
