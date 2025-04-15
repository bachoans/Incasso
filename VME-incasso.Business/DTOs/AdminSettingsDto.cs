namespace VME.incasso.Data.DTOs
{
    /// <summary>
    /// Represents global admin settings for the system.
    /// </summary>
    public class AdminSettingsDto
    {
        public int Id { get; set; }
        public decimal ReminderEmailCost { get; set; }
        public decimal ReminderMailCost { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public string CourtFee { get; set; }
    }
}
