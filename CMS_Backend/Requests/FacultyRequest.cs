using System.ComponentModel.DataAnnotations;

namespace CMS_Backend.Requests
{
    public class FacultyRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int? role_id { get; set; }
        public int? department_id { get; set; }
        public int? type_id { get; set; }
    }
}
