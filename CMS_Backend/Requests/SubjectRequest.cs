namespace CMS_Backend.Requests
{
    public class SubjectRequest
    {
        public int id { get; set; }
        public string? name { get; set; }
        public bool? is_active { get; set; } = true;
    }
}
