using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyTypeController : ControllerBase
    {
        public MyContext db { get; set; }
        public FacultyTypeController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult get()
        {
            var type = db.FacultyTypes.OrderByDescending(x => x.id).ToArray();
            return Ok(new
            {
                status = 1,
                data = type
            });
        }

        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var type = db.FacultyTypes.Where(x => x.id == id).FirstOrDefault();
            return Ok(new
            {
                status = 1,
                data = type
            });
        }

        [HttpPost]
        public IActionResult create(FacultyTypeRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var type = new FacultyType
            {
                name = request.name,
                is_active = true,
            };
            db.FacultyTypes.Add(type);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Faculty type has successfully added"
            });
        }
        [HttpPut]
        public IActionResult update(FacultyTypeRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var type = db.FacultyTypes.FirstOrDefault(x => x.id == request.id);
            if (type == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Faculty type not found",
                });
            }

            type.name = request.name;
            type.is_active = request.is_active == true ? true : false;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Faculty type updated successfully",
            });
        }

        private IActionResult validation(FacultyTypeRequest request)
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
