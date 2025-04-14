using application.DTOs.Objects.Category;
using application.Repositories.Generic;

namespace application.Repositories.Interfaces
{
    public interface IRepoCategory : IRepoGeneric<CategoryDto>
    {
        public List<CategoryDto> GetAll();
    }
}
