namespace VME.incasso.Data.Entities
{
    public class Debtor : BaseEntity
    {
        public int BuildingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Language { get; set; }

        public Building Building { get; set; }
        public ICollection<DebtRecord> DebtRecords { get; set; }
    }
}
