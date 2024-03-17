using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class College
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }
        public string? description { get; set; }

    }
}
