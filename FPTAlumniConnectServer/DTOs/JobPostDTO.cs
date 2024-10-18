namespace FPTAlumniConnectServer.DTOs
{
    public class JobPostDTO
    {
        public string JobTitle { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public DateTime Deadline { get; set; }
        public string JobDescription { get; set; }
        public bool IsPrivate { get; set; }
        public int UserID { get; set; }
    }

}
