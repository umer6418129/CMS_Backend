using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        public MyContext db { get; set; }
        public SubjectsController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subjects = db.Subjects.OrderByDescending(x => x.id).ToArray();
            return Ok(new
            {
                status = 1,
                data = subjects
            });
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var subject = db.Subjects.Where(x => x.id == id).FirstOrDefault();
            return Ok(new
            {
                status = 1,
                data = subject
            });
        }

        [HttpPost]
        public IActionResult create(SubjectRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var subject = new Subjects
            {
                name = request.name,
                is_active = true,
            };
            db.Subjects.Add(subject);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "SUbject has successfully added"
            });
        }

        [HttpPut]
        public IActionResult update(SubjectRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var subject = db.Subjects.FirstOrDefault(x => x.id == request.id);
            if (subject == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Subject not found",
                });
            }

            subject.name = request.name;
            subject.is_active = request.is_active == true ? true : false;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Subject updated successfully",
            });
        }

        private IActionResult validation(SubjectRequest request)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Name is Required"
                });
            }
            return null;
        }

    }
}
