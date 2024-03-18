using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class CollegeFaciliteis
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        [Column(TypeName = "TEXT")]
        public string? description { get; set; }

        public int? collegeId { get; set; }

        //[ForeignKey("collegeId")]
        //public College? College { get; set; }
    }
}
