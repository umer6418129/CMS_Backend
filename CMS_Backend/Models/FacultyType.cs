using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class FacultyType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public bool is_active { get; set; } = true;
    }
}
