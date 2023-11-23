namespace Entities
{
    public class EntityAudience : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? CreationUser { get; set; }
        public string? UpdateUser { get; set; }
    }
}
