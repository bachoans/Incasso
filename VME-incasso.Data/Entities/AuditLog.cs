namespace VME.incasso.Data.Entities
{
    public class AuditLog : BaseEntity
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }

        public User User { get; set; }
    }
}
