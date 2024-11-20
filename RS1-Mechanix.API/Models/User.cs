using Microsoft.AspNetCore.Identity;

namespace RS1_Mechanix.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Employee Employee { get; set; }
    }
}
