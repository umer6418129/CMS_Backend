using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        public string course_name { get; set; }
    }
}
