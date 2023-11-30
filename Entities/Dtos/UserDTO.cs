using MongoDB.Entities;

namespace Entities.Dtos
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? CreationUser { get; set; }
        public string? UpdateUser { get; set; }
    }
}
