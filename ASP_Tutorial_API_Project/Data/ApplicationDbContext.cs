using ASP_Tutorial_API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Tutorial_API_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
       

    }
}
