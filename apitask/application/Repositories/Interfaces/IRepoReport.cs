using application.DTOs.Enums;
using application.DTOs.Objects.Homework;
using application.DTOs.Others;

namespace application.Repositories.Interfaces
{
    public interface IRepoReport
    {
        public List<HomeworkWithCategory> GetByFilters(Guid? id, DateTime? date, StatusEnum? status);
        public HomeworkStatistics GetStatistics();
    }
}
