using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        public MyContext db { get; set; }
        public FeedBackController(MyContext context)
        {
            db = context;
        }
        [HttpPost]

        public IActionResult createFeedback(FeedBackRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var feedback = new StudentFeedback
            {
                std_id = request.std_id,
                description = request.description,
            };
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Feedback added successfully"
            });
        }

        private IActionResult validation(FeedBackRequest request)
        {
            var user = db.Users.FirstOrDefault(x => x.id == request.std_id);
            if (user != null)
            {
                var student = db.StudentInfos.FirstOrDefault(x => x.user_id == request.std_id);
                if (student == null)
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "Student not found"
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = 0,
                    message = "Student not found"
                });

            }
            if (string.IsNullOrEmpty(Convert.ToString(request.std_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Email is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.description))
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
