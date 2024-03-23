using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class CourseSubjects
    {
        [Key]
        public int id { get; set; }

        public int course_id { get; set; }
        public int subject_id { get; set; }

        [ForeignKey("course_id")]
        public Course? course { get; set; }
        
        [ForeignKey("subject_id")]
        public Subjects? subjects { get; set; }

    }
}
