using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        public MyContext db { get; set; }
        public FacilitiesController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult getFacilities()
        {
            var facities = db.Facilities.OrderByDescending(x => x.id);
            return Ok(new
            {
                status = 1,
                data = facities,
            });
        }
        [HttpGet("{id}")]
        public IActionResult getFacility(int id)
        {
            var facities = db.Facilities.FirstOrDefault(x => x.id == id);
            return Ok(new
            {
                status = 1,
                data = facities,
            });
        }

        [HttpPost]
        public IActionResult createFacilities(FacilitiesRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }

            var facility = new Facilities
            {
                name = request.name,
                description = request.description,
            };
            db.Facilities.Add(facility);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "facility has created"
            });
        }

        [HttpPut]
        public IActionResult updateFacilities(FacilitiesRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }

            var facility = db.Facilities.FirstOrDefault(x => x.id == request.id);
            if (facility == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "facility not found",
                });
            }


            facility.name = request.name;
            facility.description = request.description;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "facility has updated"
            });
        }

        [HttpDelete]
        public IActionResult deleteFacilities(int id)
        {
            try
            {
                var facility = db.Facilities.FirstOrDefault(x => x.id == id);
                if (facility == null)
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "facility not found"
                    });
                }
                db.Facilities.Remove(facility);
                db.SaveChanges();
                return Ok(new
                {
                    status = 1,
                    message = "facility has deleted",
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        private IActionResult validation(FacilitiesRequest request)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return Ok(new
                {
                    status = 0,
                    message = "name is Required"
                });
            }
            return null;
        }
    }
}
