namespace FPTAlumniConnectServer.Entities
{
    public partial class UserJoinEvent
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public string Content { get; set; }
        public System.DateTime Created_At { get; set; }
        public int Rating { get; set; }

        public virtual Events Events { get; set; }
        public virtual Users Users { get; set; }
    }
}
