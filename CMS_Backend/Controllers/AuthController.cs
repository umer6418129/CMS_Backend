using CMS_Backend.Helpers;
using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public MyContext db { get; set; }
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger, MyContext context)
        {
            db = context;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult login(LoginRequest login)
        {
            var user = db.Users.FirstOrDefault(x => x.email == login.email);
            if (user == null)
            {
                return Ok(new { status = 0, message = "user not found" });
            }
            if (!VerifyPassword(HashedHelper.HashPassword(login.password), user.password))
            {
                return Ok(new { status = 0, message = "invalid password" });
            }

            return Ok(new
            {
                status = 1,
                user_details = new
                {
                    name = user.name
                }
            });
        }

        

    private bool VerifyPassword(string enteredPassword, string hashedPassword)
    {
        var checkPassword = enteredPassword == hashedPassword;
        return checkPassword;
    }
}
}
