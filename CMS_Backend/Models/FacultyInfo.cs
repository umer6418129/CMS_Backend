using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class FacultyInfo
    {
        [Key]
        public int id { get; set; }
        public int? department_id { get; set; }
        public int? user_id { get; set; }
        public int? faculty_type_id { get; set; }

        [ForeignKey("department_id")]
        public Department? department { get; set; }
        
        [ForeignKey("user_id")]
        public User? user { get; set; }
        [ForeignKey("faculty_type_id")]
        public FacultyType facultyType { get; set; }
    }
}
