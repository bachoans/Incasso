namespace VME.incasso.Data.Entities
{
    public class AdminSettings : BaseEntity
    {
        public decimal ReminderEmailCost { get; set; }
        public decimal ReminderMailCost { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public decimal CourtFee { get; set; }
    }
}
