namespace FPTAlumniConnectServer.Entities
{
    public class PrivacySetting
    {
        public int Id { get; set; }
        public bool VisibleToPublic { get; set; }
        public bool VisibileToAlumni { get; set; }
        public bool VisibileToInstitution { get; set; }
        public bool VisibileToUniversity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
