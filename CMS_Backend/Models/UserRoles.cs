using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class UserRoles
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        public int? CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public College? College { get; set; }
    }
}
