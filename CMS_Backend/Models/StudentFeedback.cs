using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class StudentFeedback
    {
        [Key]
        public int? id { get; set; }
        public int? std_id { get; set; }
        public int? courseId { get; set; }
        [ForeignKey("courseId")]
        public Course course { get; set; }
        [Column(TypeName = "TEXT")]
        public string? description { get; set; }

        [ForeignKey("std_id")]
        public User? user { get; set; }

    }
}
