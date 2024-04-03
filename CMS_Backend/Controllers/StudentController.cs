using Azure.Core;
using CMS_Backend.Helpers;
using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public MyContext db { get; set; }
        public StudentController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult getStudent()
        {
            var students = db.StudentInfos.Include(x => x.user).OrderByDescending(x => x.id).ToArray();
            return Ok(new
            {
                status = 1,
                data = students
            });
        }

        [HttpPost]
        public IActionResult makeAdmission(StudentAdmissionRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            if (request.profile_image == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Faculty profile is required"
                });
            }
            var role = db.user_roles.FirstOrDefault(x => x.name == "Student");
            var user = new User
            {
                name = request.name,
                email = request.email,
                is_active = true,
                role_id = role.id,
            };
            db.Users.Add(user);
            db.SaveChanges();

            var student = new StudentInfo
            {
                std_father_name = request.std_father_name,
                std_mother_name = request.std_mother_name,
                Gender = request.Gender,
                std_date_of_birth = request.std_date_of_birth,
                std_permanent_address = request.std_permanent_address,
                std_residential_address = request.std_residential_address,
                course_id = request.course_id,
                user_id = user.id,
                addmission_status = Helpers.EnumHelper.Status.Pending,
                std_unique_id = "Std-" + (1000 + user.id),
            };
            db.StudentInfos.Add(student);
            db.SaveChanges();
            if (request.profile_image != null)
            {
                string relativePath = FileManagerHelper.Upload(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "files"), FileDirectoryHelper.studentProfile, request.profile_image, user.id, db);
            }
            return Ok(new
            {
                status = 1,
                message = "Addmission form successfuly submitted",
                studen_details = new
                {
                    stdId = student.std_unique_id,
                    addmission_status = Helpers.EnumHelper.getStatus(Convert.ToInt32(student.addmission_status)),

                }
            });
        }
        [HttpPut]
        [Route("update-status")]
        public IActionResult updateStaus(StudenAddmissionStatusRequest request)
        {
            var stdInfo = db.StudentInfos.FirstOrDefault(x => x.std_unique_id == request.id);
            var user = db.Users.FirstOrDefault(x => x.id == stdInfo.user_id);
            if (stdInfo == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Student not found",
                });
            }
            stdInfo.addmission_status = (EnumHelper.Status)request.addmission_status;
            user.is_active = request.is_active == true ? true : false;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Addmission status has updated",
            });
        }
        private IActionResult validation(StudentAdmissionRequest request)
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
                    message = "Email is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.std_father_name))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Father's Name is Required"
                });
            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.Gender)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Father's Name is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.std_permanent_address))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Permanant address is Required"
                });
            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.course_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Course is Required"
                });
            }
            return null;
        }
    }
}
