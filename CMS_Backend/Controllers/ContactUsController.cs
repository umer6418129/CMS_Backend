using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CMS_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        public MyContext db { get; set; }
        public ContactUsController(MyContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetMessage()
        {
            var data = db.ContactUs.OrderByDescending(x => x.id).ToArray();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult postMessage(ContactUsRequest contactUsRequest)
        {
            var contactUs = new ContactUs
            {
                email = contactUsRequest.email,
                full_name = contactUsRequest.full_name,
                subject = contactUsRequest.subject,
                description = contactUsRequest.description,
            };
            db.ContactUs.Add(contactUs);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Form submitted successfully"
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var data = db.ContactUs.FirstOrDefault(x => x.id == id);
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult DeleteMessageById(int id)
        {
            var data = db.ContactUs.FirstOrDefault(x => x.id == id);
            if (data == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Message not found"
                });
            }

            db.ContactUs.Remove(data);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Message has been deleted"
            });
        }
    }
}
