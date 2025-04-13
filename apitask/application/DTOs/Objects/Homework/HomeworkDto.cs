using application.DTOs.Enums;

namespace application.DTOs.Objects.Homework
{
    public class HomeworkDto
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public StatusEnum status { get; set; }
        public DateTime create_at { get; set; }
        public Guid category_id { get; set; }
    }
}
