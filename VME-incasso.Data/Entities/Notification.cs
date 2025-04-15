namespace VME.incasso.Data.Entities
{
    public class Notification : BaseEntity
    {
        public int DebtRecordId { get; set; }
        public string NotificationType { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; }

        public DebtRecord DebtRecord { get; set; }
    }
}
