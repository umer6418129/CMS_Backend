namespace CMS_Backend.Requests
{
    public class CourseRequest
    {
        public int id { get; set; }
        public string course_name { get; set; }
        public string? description { get; set; }
    }
}
