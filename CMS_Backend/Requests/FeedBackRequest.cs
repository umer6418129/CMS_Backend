using CMS_Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Requests
{
    public class FeedBackRequest
    {
        public int std_id { get; set; }
        public string? description { get; set; }

    }
}
