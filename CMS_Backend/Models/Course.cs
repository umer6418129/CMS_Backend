using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        public string course_name { get; set; }
        [Column(TypeName = "TEXT")]
        public string? description { get; set; }
        public bool is_available { get; set; } = true;
    }
}
