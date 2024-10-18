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
    public class PrivacySettingController : ControllerBase
    {
        private static List<PrivacySetting> _privacySettings = new List<PrivacySetting>();
        private static int _nextPrivacySettingId = 1;

        // POST: api/privacysetting
        [HttpPost]
        public async Task<ActionResult<PrivacySettingResponse>> CreatePrivacySetting([FromBody] PrivacySettingDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPrivacySetting = new PrivacySetting
            {
                Id = _nextPrivacySettingId++,
                VisibleToPublic = dto.VisibleToPublic,
                VisibileToAlumni = dto.VisibileToAlumni,
                VisibileToInstitution = dto.VisibileToInstitution,
                VisibileToUniversity = dto.VisibileToUniversity,
                UserId = dto.UserId
            };

            _privacySettings.Add(newPrivacySetting);

            var response = new PrivacySettingResponse
            {
                Id = newPrivacySetting.Id,
                VisibleToPublic = newPrivacySetting.VisibleToPublic,
                VisibileToAlumni = newPrivacySetting.VisibileToAlumni,
                VisibileToInstitution = newPrivacySetting.VisibileToInstitution,
                VisibileToUniversity = newPrivacySetting.VisibileToUniversity,
                UserId = newPrivacySetting.UserId
            };

            return CreatedAtAction(nameof(GetPrivacySettingById), new { id = newPrivacySetting.Id }, response);
        }

        // GET: api/privacysetting/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivacySettingResponse>> GetPrivacySettingById(int id)
        {
            var privacySetting = _privacySettings.FirstOrDefault(p => p.Id == id);

            if (privacySetting == null)
            {
                return NotFound($"Privacy setting with ID {id} not found.");
            }

            var response = new PrivacySettingResponse
            {
                Id = privacySetting.Id,
                VisibleToPublic = privacySetting.VisibleToPublic,
                VisibileToAlumni = privacySetting.VisibileToAlumni,
                VisibileToInstitution = privacySetting.VisibileToInstitution,
                VisibileToUniversity = privacySetting.VisibileToUniversity,
                UserId = privacySetting.UserId
            };

            return Ok(response);
        }

        // PUT: api/privacysetting/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrivacySetting(int id, [FromBody] PrivacySettingDTO dto)
        {
            var privacySetting = _privacySettings.FirstOrDefault(p => p.Id == id);

            if (privacySetting == null)
            {
                return NotFound($"Privacy setting with ID {id} not found.");
            }

            privacySetting.VisibleToPublic = dto.VisibleToPublic;
            privacySetting.VisibileToAlumni = dto.VisibileToAlumni;
            privacySetting.VisibileToInstitution = dto.VisibileToInstitution;
            privacySetting.VisibileToUniversity = dto.VisibileToUniversity;
            privacySetting.UserId = dto.UserId;

            return NoContent();
        }

        // DELETE: api/privacysetting/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivacySetting(int id)
        {
            var privacySetting = _privacySettings.FirstOrDefault(p => p.Id == id);

            if (privacySetting == null)
            {
                return NotFound($"Privacy setting with ID {id} not found.");
            }

            _privacySettings.Remove(privacySetting);

            return NoContent();
        }
    }
}
