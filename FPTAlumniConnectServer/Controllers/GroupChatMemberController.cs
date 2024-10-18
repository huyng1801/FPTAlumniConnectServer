using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatMemberController : ControllerBase
    {
        private static List<GroupChatMember> _groupChatMembers = new List<GroupChatMember>();
        private static int _nextMemberId = 1;

        // POST: api/groupchatmember
        [HttpPost]
        public async Task<ActionResult<GroupChatMemberResponse>> AddGroupChatMember([FromBody] GroupChatMemberDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMember = new GroupChatMember
            {
                Id = _nextMemberId++,
                GroupChatId = dto.GroupChatId,
                UserId = dto.UserId,
                AddedByUserId = dto.AddedByUserId,
                IsLeaved = false,
                IsBlock = false,
                CreatedAt = DateTime.UtcNow
            };

            _groupChatMembers.Add(newMember);

            var response = new GroupChatMemberResponse
            {
                Id = newMember.Id,
                GroupChatId = newMember.GroupChatId,
                UserId = newMember.UserId,
                UserName = $"User_{newMember.UserId}", // Placeholder for username
                IsLeaved = newMember.IsLeaved,
                IsBlocked = newMember.IsBlock,
                CreatedAt = newMember.CreatedAt,
                AddedByUserId = newMember.AddedByUserId,
                AddedByUserName = newMember.AddedByUserId.HasValue ? $"User_{newMember.AddedByUserId.Value}" : null
            };

            return CreatedAtAction(nameof(GetGroupChatMemberById), new { id = newMember.Id }, response);
        }

        // GET: api/groupchatmember/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupChatMemberResponse>> GetGroupChatMemberById(int id)
        {
            var member = _groupChatMembers.FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                return NotFound($"GroupChatMember with ID {id} not found.");
            }

            var response = new GroupChatMemberResponse
            {
                Id = member.Id,
                GroupChatId = member.GroupChatId,
                UserId = member.UserId,
                UserName = $"User_{member.UserId}", // Placeholder for username
                IsLeaved = member.IsLeaved,
                IsBlocked = member.IsBlock,
                CreatedAt = member.CreatedAt,
                AddedByUserId = member.AddedByUserId,
                AddedByUserName = member.AddedByUserId.HasValue ? $"User_{member.AddedByUserId.Value}" : null
            };

            return Ok(response);
        }

        // PUT: api/groupchatmember/{id}/block
        [HttpPut("{id}/block")]
        public async Task<ActionResult<GroupChatMemberResponse>> BlockGroupChatMember(int id)
        {
            var member = _groupChatMembers.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound($"GroupChatMember with ID {id} not found.");
            }

            member.IsBlock = true;

            var response = new GroupChatMemberResponse
            {
                Id = member.Id,
                GroupChatId = member.GroupChatId,
                UserId = member.UserId,
                UserName = $"User_{member.UserId}", // Placeholder for username
                IsLeaved = member.IsLeaved,
                IsBlocked = member.IsBlock,
                CreatedAt = member.CreatedAt,
                AddedByUserId = member.AddedByUserId,
                AddedByUserName = member.AddedByUserId.HasValue ? $"User_{member.AddedByUserId.Value}" : null
            };

            return Ok(response);
        }

        // PUT: api/groupchatmember/{id}/leave
        [HttpPut("{id}/leave")]
        public async Task<ActionResult<GroupChatMemberResponse>> MarkAsLeaved(int id)
        {
            var member = _groupChatMembers.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound($"GroupChatMember with ID {id} not found.");
            }

            member.IsLeaved = true;

            var response = new GroupChatMemberResponse
            {
                Id = member.Id,
                GroupChatId = member.GroupChatId,
                UserId = member.UserId,
                UserName = $"User_{member.UserId}", // Placeholder for username
                IsLeaved = member.IsLeaved,
                IsBlocked = member.IsBlock,
                CreatedAt = member.CreatedAt,
                AddedByUserId = member.AddedByUserId,
                AddedByUserName = member.AddedByUserId.HasValue ? $"User_{member.AddedByUserId.Value}" : null
            };

            return Ok(response);
        }

        // DELETE: api/groupchatmember/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGroupChatMember(int id)
        {
            var member = _groupChatMembers.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound($"GroupChatMember with ID {id} not found.");
            }

            _groupChatMembers.Remove(member);

            return NoContent();
        }
    }
}
