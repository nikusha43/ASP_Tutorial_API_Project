using System.Security.Principal;

namespace ASP_Tutorial_API_Project.Models
{
    public class UpdateContactRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Addres { get; set; }
    }
}
