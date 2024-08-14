namespace ECommerce.Shared.Commands
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
