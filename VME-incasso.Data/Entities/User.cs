namespace VME.incasso.Data.Entities
{
    public class User : BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? AccountLockedUntil { get; set; }

        public Company Company { get; set; }
    }
}
