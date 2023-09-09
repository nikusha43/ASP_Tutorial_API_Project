using ASP_Tutorial_API_Project.Data;
using ASP_Tutorial_API_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Tutorial_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext db;
        public ContactsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            
            return Ok(await db.Contacts.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSingleContact([FromRoute] Guid id)
        {
            var contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();

            }
            return Ok(contact); 

        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContaxtRequests ACR)
        {

            var cotact = new Contact()
            {
                Id=Guid.NewGuid(),
                Addres=ACR.Addres,
                Phone=ACR.Phone,
                FullName=ACR.FullName,
                Email = ACR.Email
            };

            await db.Contacts.AddAsync(cotact);
            await db.SaveChangesAsync();

            return Ok(cotact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest UCR)
        {
            var contact = await db.Contacts.FindAsync(id);

            if(contact != null)
            {
                contact.FullName = UCR.FullName;    
                contact.Phone = UCR.Phone;
                contact.Email = UCR.Email;
                contact.Addres = UCR.Addres;

               await  db.SaveChangesAsync();


                return Ok(contact); 
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteConact([FromRoute] Guid id)
        {
          var contact=   await db.Contacts.FindAsync(id);

            if(contact != null)
            {
                db.Contacts.Remove(contact);
                await db.SaveChangesAsync();
                return Ok(contact);
            }
           return NotFound();    
        }

    }
}
