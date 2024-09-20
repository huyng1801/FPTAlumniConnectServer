using Microsoft.Extensions.Hosting;

namespace FPTAlumniConnectServer.Entities
{
    public class Comments
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int AuthId { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }

        public virtual Posts Posts { get; set; }
    }
}
