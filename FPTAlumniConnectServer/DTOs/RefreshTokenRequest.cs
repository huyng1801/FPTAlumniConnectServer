using System.ComponentModel.DataAnnotations;

namespace FPTAlumniConnectServer.DTOs
{
    public class RefreshTokenRequest
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
