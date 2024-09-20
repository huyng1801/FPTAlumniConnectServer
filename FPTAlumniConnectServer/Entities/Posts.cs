namespace FPTAlumniConnectServer.Entities
{
    public partial class Posts
    {
        public int PostID { get; set; }
        public int BoardID { get; set; }
        public int AuthID { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
