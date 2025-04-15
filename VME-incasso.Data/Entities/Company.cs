namespace VME.incasso.Data.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Building> Buildings { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
