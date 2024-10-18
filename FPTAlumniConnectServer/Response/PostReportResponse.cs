namespace FPTAlumniConnectServer.Response
{
    public class PostReportResponse
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } // Optional: Include user's name for better display
    }
}
