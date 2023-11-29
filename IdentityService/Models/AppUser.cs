using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class AppUser : BaseEntity
    {        
        public string UserName { get; set; } = string.Empty;       
        public string Email { get; set; } = string.Empty;        
        public byte[]? Password { get; set; } 
        public byte[]? Salt { get; set; } 
    }
}
