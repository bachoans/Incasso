namespace VME.incasso.Data.DTOs
{
    /// <summary>
    /// Represents a record of user actions for auditing purposes.
    /// </summary>
    public class AuditLogDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public DateTime SysDate { get; set; }
    }
}