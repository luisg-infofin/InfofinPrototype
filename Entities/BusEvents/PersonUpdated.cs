namespace Entities.BusEvents
{
    public class PersonUpdated
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }       
        public DateTime UpdateAt { get; set; }        
        public string? UpdateUser { get; set; }
    }
}
