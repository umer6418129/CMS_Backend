using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public bool is_active { get; set; } = true;
    }
}
