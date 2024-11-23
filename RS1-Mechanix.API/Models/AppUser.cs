using Microsoft.AspNetCore.Identity;
using RS1_Mechanix.Models;

namespace RS1_Mechanix.API.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Employee? Employee { get; set; }

    }
}
