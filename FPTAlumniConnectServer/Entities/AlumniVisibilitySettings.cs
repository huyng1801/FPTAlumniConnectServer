namespace FPTAlumniConnectServer.Entities
{
    public class AlumniVisibilitySettings
    {//
        public int Id { get; set; }
        public int AlumniId { get; set; }
        public bool VisibleToPublic { get; set; }
        public bool VisibileToAlumni { get; set; }
        public bool VisibileToInstitution { get; set; }
        public bool VisibileToUniversity { get; set; }
    }
}
