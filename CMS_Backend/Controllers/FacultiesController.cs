using CMS_Backend.Helpers;
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
        public IWebHostEnvironment _hostingEnvironment { get; set; }
        public FacultiesController(MyContext context, IWebHostEnvironment hostingEnvironment)
        {
            db = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult getFaculties()
        {
            var faculties = db.FacultyInfos.Include(x => x.user).Include(x => x.facultyType).Where(f => f.user.is_active == true && f.facultyType.is_active == true).Select(u => new
            {
                id = u.id,
                userId = u.user.id,
                name = u.user.name,
                email = u.user.email,
                department_id = u.department_id,
                faculty_type_id = u.faculty_type_id,
                department = u.department.name,
                type = u.facultyType.name,
                profile_image = db.FileRepos.Where(p => p.tbl_name == "faculty-profile" && p.rowId == u.user.id).Select(p => new
                {
                    path = p.file_name,
                }).FirstOrDefault()
            }).ToArray();

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

            if (request.profile_image != null)
            {
                string relativePath = FileManagerHelper.Upload(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "files"), FileDirectoryHelper.facultyProfile, request.profile_image, user.id, db);
            }
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
            if (request.profile_image != null)
            {
                FileManagerHelper.Update(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "files"), FileDirectoryHelper.facultyProfile, request.profile_image, user.id, db);
            }

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
            //else if (string.IsNullOrEmpty(Convert.ToString(request.role_id)))
            //{
            //    return Ok(new
            //    {
            //        status = 0,
            //        message = "Role is Required"
            //    });

            //}
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
