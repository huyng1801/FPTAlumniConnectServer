using Microsoft.Extensions.Hosting;

namespace FPTAlumniConnectServer.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }  
    }
}
