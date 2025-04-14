using application.DTOs.Enums;
using application.DTOs.Objects.Category;

namespace application.DTOs.Objects.Homework
{
    public class HomeworkWithCategory
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public StatusEnum status { get; set; }
        public DateTime create_at { get; set; }
        public CategoryDto category { get; set; }
    }
}
