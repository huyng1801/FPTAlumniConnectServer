using FPTAlumniConnectServer.Entities;

namespace FPTAlumniConnectServer.Response
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public PostStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }  // Return the UserId
        public UserResponse User { get; set; }  // Include UserResponse
        public CategoryResponse Category { get; set; }  // Include CategoryResponse
    }
}
