using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public MyContext db { get; set; }
        public DepartmentController(MyContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var departments = db.Departments.OrderByDescending(x => x.id).ToArray();
                return Ok(new
                {
                    status = 1,
                    data = departments,
                });

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var departments = db.Departments.FirstOrDefault(x => x.id == id);
                return Ok(new
                {
                    status = 1,
                    data = departments,
                });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Post(DepartmentRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var department = new Department
            {
                name = request.name
            };
            db.Departments.Add(department);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Department has created",
            });
        }

        [HttpPut]
        public IActionResult Put(DepartmentRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var department = db.Departments.FirstOrDefault(x => x.id == request.id);
            if (department == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Department not found",
                });

            }
            department.name = request.name;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Department has updated",
            });
        }

        private IActionResult validation(DepartmentRequest request)
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
