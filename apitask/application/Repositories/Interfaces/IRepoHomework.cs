using application.DTOs.Objects.Homework;
using application.Repositories.Generic;

namespace application.Repositories.Interfaces
{
    public interface IRepoHomework : IRepoGeneric<HomeworkDto>
    {
        public List<HomeworkDto> GetAll();
        public HomeworkWithCategory GetIdWithCategory(Guid id);
        public List<HomeworkWithCategory> GetWithCategories();  
    }
}
