using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class CourseFaculties
    {
        [Key]
        public int id { get; set; }

        public int course_id { get; set; }
        public int faculty_id { get; set; }

        [ForeignKey("course_id")]
        public Course? course { get; set; }

        [ForeignKey("faculty_id")]
        public User? user{ get; set; }
    }
}
