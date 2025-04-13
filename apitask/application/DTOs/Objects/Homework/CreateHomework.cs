using application.DTOs.Enums;

namespace application.DTOs.Objects.Homework
{
    public class CreateHomework
    {
        public Guid category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public StatusEnum status { get; set; }
    }
}
