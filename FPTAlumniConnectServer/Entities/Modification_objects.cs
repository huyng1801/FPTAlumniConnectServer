namespace FPTAlumniConnectServer.Entities
{
    public partial class Modification_objects
    {
        public int Id { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public string Status { get; set; }
    }
}
