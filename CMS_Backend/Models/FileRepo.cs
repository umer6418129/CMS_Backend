using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class FileRepo
    {
        [Key]
        public int id { get; set; }

        public int rowId { get; set; }

        public string tbl_name { get; set; }

        [Column(TypeName = "TEXT")]
        public string file_name { get; set;}

    }
}
