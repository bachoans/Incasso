namespace VME.incasso.Data.DTOs
{
    /// <summary>
    /// Represents a single notification entry associated with a debt record.
    /// </summary>
    public class NotificationDto
    {
        public int Id { get; set; }

        /// <summary>
        /// The ID of the related debt record.
        /// </summary>
        public int DebtRecordId { get; set; }

        /// <summary>
        /// Type of notification (e.g. ReminderEmail, CourtLetter).
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Date and time the notification was sent.
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Status of the notification (e.g. Sent, Failed, Pending).
        /// </summary>
        public string Status { get; set; }
    }
}
