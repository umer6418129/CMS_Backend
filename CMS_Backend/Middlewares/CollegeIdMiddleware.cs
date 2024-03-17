using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace CMS_Backend.Middlewares
{
    public class CollegeIdMiddleware
    {
        private readonly RequestDelegate _next;

        public CollegeIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("college_id", out var collegeIdHeader))
            {
                if (int.TryParse(collegeIdHeader, out int collegeId))
                {
                    context.Items["CollegeId"] = collegeId;
                }
            }
            await _next(context);
        }
    }
}
