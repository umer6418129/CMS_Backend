using CMS_Backend.Helpers;

namespace CMS_Backend.Requests
{
    public class StudenAddmissionStatusRequest
    {
        public string id { get; set; }
        public int addmission_status { get; set; }
        public bool is_active { get; set; }
    }
}
