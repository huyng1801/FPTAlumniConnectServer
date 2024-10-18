using FPTAlumniConnectServer.DTOs;
using FPTAlumniConnectServer.Entities;
using FPTAlumniConnectServer.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FPTAlumniConnectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatController : ControllerBase
    {
        private static List<GroupChat> _groupChats = new List<GroupChat>();
        private static List<GroupChatMember> _groupChatMembers = new List<GroupChatMember>();
        private static int _nextGroupId = 1;

        // POST: api/groupchat
        [HttpPost]
        public async Task<ActionResult<GroupChatResponse>> CreateGroupChat([FromBody] GroupChatDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupChat = new GroupChat
            {
                Id = _nextGroupId++,
                GroupName = dto.GroupName,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                GroupChatMembers = new Collection<GroupChatMember>()
            };

            _groupChats.Add(groupChat);

            var response = new GroupChatResponse
            {
                Id = groupChat.Id,
                GroupName = groupChat.GroupName,
                UserId = groupChat.UserId,
                UserName = $"User_{groupChat.UserId}", // Placeholder for user name
                CreatedAt = groupChat.CreatedAt,
                UpdatedAt = groupChat.UpdatedAt,
                Members = new List<GroupChatMemberResponse>()
            };

            return CreatedAtAction(nameof(GetGroupChatById), new { id = groupChat.Id }, response);
        }

        // GET: api/groupchat/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupChatResponse>> GetGroupChatById(int id)
        {
            var groupChat = _groupChats.FirstOrDefault(gc => gc.Id == id);

            if (groupChat == null)
            {
                return NotFound($"GroupChat with ID {id} not found.");
            }

            var response = new GroupChatResponse
            {
                Id = groupChat.Id,
                GroupName = groupChat.GroupName,
                UserId = groupChat.UserId,
                UserName = $"User_{groupChat.UserId}", // Placeholder for user name
                CreatedAt = groupChat.CreatedAt,
                UpdatedAt = groupChat.UpdatedAt,
                Members = groupChat.GroupChatMembers.Select(member => new GroupChatMemberResponse
                {
                    UserId = member.UserId,
                    UserName = $"User_{member.UserId}" // Placeholder for user name
                }).ToList()
            };

            return Ok(response);
        }

        // PUT: api/groupchat/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupChatResponse>> UpdateGroupChat(int id, [FromBody] GroupChatDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupChat = _groupChats.FirstOrDefault(gc => gc.Id == id);
            if (groupChat == null)
            {
                return NotFound($"GroupChat with ID {id} not found.");
            }

            groupChat.GroupName = dto.GroupName;
            groupChat.UpdatedAt = DateTime.UtcNow;

            var response = new GroupChatResponse
            {
                Id = groupChat.Id,
                GroupName = groupChat.GroupName,
                UserId = groupChat.UserId,
                UserName = $"User_{groupChat.UserId}", // Placeholder for user name
                CreatedAt = groupChat.CreatedAt,
                UpdatedAt = groupChat.UpdatedAt,
                Members = groupChat.GroupChatMembers.Select(member => new GroupChatMemberResponse
                {
                    UserId = member.UserId,
                    UserName = $"User_{member.UserId}" // Placeholder for user name
                }).ToList()
            };

            return Ok(response);
        }

        // DELETE: api/groupchat/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupChat(int id)
        {
            var groupChat = _groupChats.FirstOrDefault(gc => gc.Id == id);
            if (groupChat == null)
            {
                return NotFound($"GroupChat with ID {id} not found.");
            }

            _groupChats.Remove(groupChat);

            return NoContent();
        }

        // POST: api/groupchat/{id}/addmember
        [HttpPost("{id}/addmember")]
        public async Task<ActionResult<GroupChatResponse>> AddMemberToGroupChat(int id, [FromBody] int userId)
        {
            var groupChat = _groupChats.FirstOrDefault(gc => gc.Id == id);
            if (groupChat == null)
            {
                return NotFound($"GroupChat with ID {id} not found.");
            }

            var newMember = new GroupChatMember
            {
                UserId = userId,
                GroupChatId = groupChat.Id
            };

            groupChat.GroupChatMembers.Add(newMember);

            var response = new GroupChatResponse
            {
                Id = groupChat.Id,
                GroupName = groupChat.GroupName,
                UserId = groupChat.UserId,
                UserName = $"User_{groupChat.UserId}", // Placeholder for user name
                CreatedAt = groupChat.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
                Members = groupChat.GroupChatMembers.Select(member => new GroupChatMemberResponse
                {
                    UserId = member.UserId,
                    UserName = $"User_{member.UserId}" // Placeholder for user name
                }).ToList()
            };

            return Ok(response);
        }

        // DELETE: api/groupchat/{id}/removemember
        [HttpPost("{id}/removemember")]
        public async Task<ActionResult<GroupChatResponse>> RemoveMemberFromGroupChat(int id, [FromBody] int userId)
        {
            var groupChat = _groupChats.FirstOrDefault(gc => gc.Id == id);
            if (groupChat == null)
            {
                return NotFound($"GroupChat with ID {id} not found.");
            }

            var memberToRemove = groupChat.GroupChatMembers.FirstOrDefault(m => m.UserId == userId);
            if (memberToRemove == null)
            {
                return NotFound($"Member with User ID {userId} not found in the group.");
            }

            groupChat.GroupChatMembers.Remove(memberToRemove);

            var response = new GroupChatResponse
            {
                Id = groupChat.Id,
                GroupName = groupChat.GroupName,
                UserId = groupChat.UserId,
                UserName = $"User_{groupChat.UserId}", // Placeholder for user name
                CreatedAt = groupChat.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
                Members = groupChat.GroupChatMembers.Select(member => new GroupChatMemberResponse
                {
                    UserId = member.UserId,
                    UserName = $"User_{member.UserId}" // Placeholder for user name
                }).ToList()
            };

            return Ok(response);
        }
    }
}
