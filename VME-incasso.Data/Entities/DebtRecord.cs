using VME.incasso.Data.Enumerations;

namespace VME.incasso.Data.Entities
{
    public class DebtRecord : BaseEntity
    {
        public int DebtorId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime InterestStartDate { get; set; }
        public string Description { get; set; }
        public DebtStatus Status { get; set; }

        public Debtor Debtor { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
