using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Models
{
    public class Subjects
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public bool? is_active { get; set; } = true;
    }
}
