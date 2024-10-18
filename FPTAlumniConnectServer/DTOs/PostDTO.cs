using FPTAlumniConnectServer.Entities;

namespace FPTAlumniConnectServer.DTOs
{

    public class PostDTO
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public PostStatusEnum Status { get; set; }
    }
}
