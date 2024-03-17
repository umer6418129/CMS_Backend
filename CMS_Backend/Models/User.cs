using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string name { get; set; }
        [Required]
        [StringLength(150)]
        public string email { get; set; }
        
        [Required]
        [StringLength(150)]
        public string password { get; set; }

        public int? collegeId { get; set; }
        public int? role_id { get; set; }

        [ForeignKey("collegeId ")]
        public College? College { get; set; } = null;
        
        [ForeignKey("role_id")]
        public UserRoles? user_roles { get; set; } = null;


    }
}
