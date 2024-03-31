using CMS_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        public MyContext db;
        public CourseCategoryController(MyContext context) {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = db.CourseCategories.Where(x => x.is_active == true).AsNoTracking().ToList();
            return Ok(new
            {
                status = 1,
                data = categories
            });
        }
    }
}
