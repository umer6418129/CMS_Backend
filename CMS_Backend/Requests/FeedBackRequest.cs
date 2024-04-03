using CMS_Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Requests
{
    public class FeedBackRequest
    {
        public int id { get; set; }
        public string? std_id { get; set; }
        public int? courseId { get; set; }
        public string? description { get; set; }

    }
}
