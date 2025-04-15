namespace VME.incasso.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime SysDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }

}
