using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        public MyContext db { get; set; }
        public FacultiesController(MyContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult getFaculties()
        {
            var faculties = db.FacultyInfos.Include(x => x.user).Include(x => x.facultyType).Where(f => f.user.is_active == true).Where(x => x.facultyType.is_active == true).ToArray();
            return Ok(new
            {
                status = 1,
                data = faculties
            });
        }

        [HttpGet("{id}")]
        public IActionResult getFaculty(int id)
        {
            var faculties = db.FacultyInfos.Include(x => x.user).FirstOrDefault(x => x.id == id);
            return Ok(new
            {
                status = 1,
                data = faculties
            });
        }

        [HttpPost]
        public IActionResult CreateFaculty(FacultyRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }

            var role = db.user_roles.FirstOrDefault(x => x.name == "Faculty");
            if (role == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Faculty role not found"
                });
            }

            var user = new User
            {
                name = request.name,
                email = request.email,
                role_id = role.id,
            };
            db.Users.Add(user);
            db.SaveChanges();

            var faculty = new FacultyInfo
            {
                department_id = request.department_id,
                user_id = user.id,
                faculty_type_id = request.type_id
            };
            db.FacultyInfos.Add(faculty);
            db.SaveChanges();

            return Ok(new
            {
                status = 1,
                message = "Faculty added successfully"
            });
        }

        [HttpPut]
        public IActionResult updateFaculty(FacultyRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var faculty = db.FacultyInfos.FirstOrDefault(x => x.id == request.id);
            var user = db.Users.FirstOrDefault(x => x.id == faculty.user_id);
            if (faculty == null || user == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Faculty not found"
                });
            }

            user.email = request.email;
            user.name = request.name;
            faculty.department_id = request.department_id;
            faculty.faculty_type_id = request.type_id;
            db.SaveChanges();

            return Ok(new
            {
                status = 1,
                message = "Faculty updated"
            });

        }


        private IActionResult validation(FacultyRequest request)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Name is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.email))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Name is Required"
                });

            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.department_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Department is Required"
                });

            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.role_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Role is Required"
                });

            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.type_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Type is Required"
                });

            }
            return null;
        }
    }
}
