namespace FPTAlumniConnectServer.Response
{
    public class JobApplicationResponse
    {
        public int Id { get; set; }
        public int JobPostId { get; set; }
        public int UserId { get; set; }
        public string ApplicantName { get; set; }
        public string CVFileUrl { get; set; }
        public string CoverLetter { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
    }
}
