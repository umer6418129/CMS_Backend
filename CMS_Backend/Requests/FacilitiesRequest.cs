using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Requests
{
    public class FacilitiesRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
    }
}
