using CMS_Backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Requests
{
    public class StudentAdmissionRequest
    {
        public string name { get; set; }
        public string email { get; set; }
        public string std_father_name { get; set; }
        public string? std_mother_name { get; set; }
        public DateTime std_date_of_birth { get; set; }
        public EnumHelper.Gender Gender { get; set; }
        public string? std_residential_address { get; set; }
        public string std_permanent_address { get; set; }
        public int? course_id { get; set; }
    }
}
