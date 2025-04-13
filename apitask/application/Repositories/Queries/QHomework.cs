using application.DataAccess;
using application.DTOs.Objects.Homework;
using application.Models;
using application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace application.Repositories.Queries
{
    public class QHomework : IRepoHomework
    {
        private readonly DataBaseContext _context = new();
        
        public int Create(HomeworkDto dto)
        {
            Homework homework = Automapper.Mapper!.Map<Homework>(dto);
            _context.Homeworks.Add(homework);
            return _context.SaveChanges();
        }

        public HomeworkDto GetById(Guid id)
        {
            Homework? homework = _context.Homeworks.AsNoTracking().FirstOrDefault(u => u.id == id);
            return Automapper.Mapper!.Map<HomeworkDto>(homework);
        }

        public int Update(HomeworkDto dto)
        {
            Homework homework = Automapper.Mapper!.Map<Homework>(dto);
            _context.Homeworks.Update(homework);
            return _context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            Homework? homework = _context.Homeworks.FirstOrDefault(c => c.id == id);
            if (homework == null) return 0;
            _context.Homeworks.Remove(homework);
            return _context.SaveChanges();
        }

        public List<HomeworkDto> GetAll()
        {
            return Automapper.Mapper!.Map<List<HomeworkDto>>(_context.Homeworks.ToList());
        }
    }
}
