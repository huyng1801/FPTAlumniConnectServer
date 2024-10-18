namespace FPTAlumniConnectServer.Response
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public bool IsHide { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
    }
}
