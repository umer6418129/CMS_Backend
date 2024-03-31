using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


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
        public bool? is_featured { get; set; }
        public int? category_id { get; set; }
        [ForeignKey("category_id")]
        public CourseCategory CourseCategory { get; set; }

        [JsonIgnore]
        public ICollection<CourseSubjects> CourseSubjects { get; set; }
    }
}
