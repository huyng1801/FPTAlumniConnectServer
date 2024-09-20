namespace FPTAlumniConnectServer.Entities
{
    public partial class Events
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Location { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> OrganizerId { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public virtual Users Users { get; set; }
    }
}
