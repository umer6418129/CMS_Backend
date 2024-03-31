using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class CourseCategory
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public bool? is_active { get; set; }
    }
}
