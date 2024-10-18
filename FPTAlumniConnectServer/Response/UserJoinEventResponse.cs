namespace FPTAlumniConnectServer.Response
{
    public class UserJoinEventResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } // Assuming User has a name
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
    }
}
