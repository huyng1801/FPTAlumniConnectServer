namespace FPTAlumniConnectServer.DTOs
{
    public class EventDTO
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; } // File input for Image
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public bool IsHide { get; set; }
        public int UserId { get; set; }
    }
}
