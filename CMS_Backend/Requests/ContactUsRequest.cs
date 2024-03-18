namespace CMS_Backend.Requests
{
    public class ContactUsRequest
    {
        public string full_name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
    }
}
