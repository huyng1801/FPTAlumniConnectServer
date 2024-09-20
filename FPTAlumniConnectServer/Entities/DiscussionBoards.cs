namespace FPTAlumniConnectServer.Entities
{
    public partial class DiscussionBoards
    {
        public int BoardID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public bool IsPrivate { get; set; }
    }
}
