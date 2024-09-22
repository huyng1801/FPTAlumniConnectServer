using FPTAlumniConnectServer.Entities;
using System.ComponentModel.DataAnnotations;

namespace FPTAlumniConnectServer.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; set; }

        public bool EmailConfirmed { get; set; }

        [Url(ErrorMessage = "Invalid URL.")]
        public string? ProfilePictureUrl { get; set; }

        [Required]
        public RoleEnum Role { get; set; }

        [StringLength(500, ErrorMessage = "Education History cannot be longer than 500 characters.")]
        public string? EducationHistory { get; set; }

        [StringLength(100, ErrorMessage = "Major cannot be longer than 100 characters.")]
        public string? Major { get; set; }

        public bool IsMentor { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
