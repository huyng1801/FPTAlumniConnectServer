namespace FPTAlumniConnectServer.DTOs
{
    public class JobApplicationDTO
    {
        public int JobPostId { get; set; }
        public int UserId { get; set; }
        public string ApplicantName { get; set; }
        public string CVFileUrl { get; set; }
        public string CoverLetter { get; set; }
    }
}
