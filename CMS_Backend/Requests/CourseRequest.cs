namespace CMS_Backend.Requests
{
    public class CourseRequest
    {
        public int id { get; set; }
        public string course_name { get; set; }
        public string? description { get; set; }
        public bool is_available { get; set; }
        public int? category_id { get; set; }
        public int[] subject_ids { get; set; }
        public int[] faculties_id { get; set; }
        public int? no_of_classes { get; set; }
        public string? course_duration { get; set; }

        public IFormFile? course_image { get; set; }
    }
}
