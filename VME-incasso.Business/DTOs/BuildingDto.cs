namespace VME.incasso.Data.DTOs
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankAccount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public string CourtJurisdiction { get; set; }
    }
}
