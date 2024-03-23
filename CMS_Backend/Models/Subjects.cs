using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CMS_Backend.Models
{
    public class Subjects
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public bool? is_active { get; set; } = true;
        //public ICollection<CourseSubjects> CourseSubjects { get; set; }

    }
}
