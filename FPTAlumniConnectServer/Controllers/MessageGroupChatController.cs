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
    public class MessageGroupChatController : ControllerBase
    {
        private static List<MessageGroupChat> _messages = new List<MessageGroupChat>();
        private static int _nextMessageId = 1;

        // POST: api/messagegroupchat
        [HttpPost]
        public async Task<ActionResult<MessageGroupChatResponse>> CreateMessage([FromBody] MessageGroupChatDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMessage = new MessageGroupChat
            {
                Id = _nextMessageId++,
                MemberId = dto.MemberId,
                Content = dto.Content,
                CreateAt = DateTime.UtcNow
            };

            _messages.Add(newMessage);

            var response = new MessageGroupChatResponse
            {
                Id = newMessage.Id,
                MemberId = newMessage.MemberId,
                MemberUserName = $"User_{newMessage.MemberId}", // Placeholder for the actual member username
                Content = newMessage.Content,
                CreateAt = newMessage.CreateAt
            };

            return CreatedAtAction(nameof(GetMessageById), new { id = newMessage.Id }, response);
        }

        // GET: api/messagegroupchat/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageGroupChatResponse>> GetMessageById(int id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);

            if (message == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }

            var response = new MessageGroupChatResponse
            {
                Id = message.Id,
                MemberId = message.MemberId,
                MemberUserName = $"User_{message.MemberId}", // Placeholder for the actual member username
                Content = message.Content,
                CreateAt = message.CreateAt
            };

            return Ok(response);
        }

        // GET: api/messagegroupchat/group/{groupId}
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<MessageGroupChatResponse>>> GetMessagesByGroupId(int groupId)
        {
            var messages = _messages.Where(m => m.GroupChatMember.GroupChatId == groupId).ToList();

            if (messages.Count == 0)
            {
                return NotFound($"No messages found for Group ID {groupId}.");
            }

            var response = messages.Select(m => new MessageGroupChatResponse
            {
                Id = m.Id,
                MemberId = m.MemberId,
                MemberUserName = $"User_{m.MemberId}", // Placeholder for the actual member username
                Content = m.Content,
                CreateAt = m.CreateAt
            }).ToList();

            return Ok(response);
        }

        // DELETE: api/messagegroupchat/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = _messages.FirstOrDefault(m => m.Id == id);

            if (message == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }

            _messages.Remove(message);

            return NoContent();
        }
    }
}
