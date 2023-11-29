using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{    
    public class User : EntityAudience
    {                
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

    }
}
