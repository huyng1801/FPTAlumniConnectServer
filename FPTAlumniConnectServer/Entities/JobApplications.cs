namespace FPTAlumniConnectServer.Entities
{
    public partial class JobApplications
    {
        public int ApplicationID { get; set; }
        public int JobPostID { get; set; }
        public int UserID { get; set; }
        public string Resume { get; set; }
        public string CV { get; set; }

        public virtual JobPosts JobPosts { get; set; }
        public virtual Users Users { get; set; }
    }
}
