namespace FPTAlumniConnectServer.DTOs
{
    public class UserJoinEventDTO
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
