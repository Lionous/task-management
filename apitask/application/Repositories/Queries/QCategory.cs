using application.DataAccess;
using application.DTOs.Objects.Category;
using application.Models;
using application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace application.Repositories.Queries
{
    public class QCategory : IRepoCategory
    {
        private readonly DataBaseContext _context = new();
        
        public int Create(CategoryDto dto)
        {
            Category category = Automapper.Mapper!.Map<Category>(dto);
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public CategoryDto GetById(Guid id)
        {
            Category? category = _context.Categories.AsNoTracking().FirstOrDefault(u => u.id == id);
            return Automapper.Mapper!.Map<CategoryDto>(category);
        }

        public int Update(CategoryDto dto)
        {
            Category category = Automapper.Mapper!.Map<Category>(dto);
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.id == id);
            if (category == null) return 0;
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }

        public List<CategoryDto> GetAll()
        {
            return Automapper.Mapper!.Map<List<CategoryDto>>(_context.Categories.ToList());
        }
    }
}
