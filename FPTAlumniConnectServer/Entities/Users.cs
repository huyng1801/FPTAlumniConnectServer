namespace FPTAlumniConnectServer.Entities
{
    public partial class Users
    {//
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ProfilePictureUrl { get; set; }
        public RoleEnum Role { get; set; }
        public string EducationHistory { get; set; }
        public string Major { get; set; }
        public bool IsMentor { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
