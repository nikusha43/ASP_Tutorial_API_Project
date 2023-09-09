using System.Security.Principal;

namespace ASP_Tutorial_API_Project.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Addres { get; set; }
    }
}
