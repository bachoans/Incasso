namespace VME.incasso.Data.Entities
{
    public class Building : BaseEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankAccount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public string CourtJurisdiction { get; set; }

        public Company Company { get; set; }
        public ICollection<Debtor> Debtors { get; set; }
    }
}
