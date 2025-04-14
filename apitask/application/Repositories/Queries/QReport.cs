using application.DataAccess;
using application.DTOs.Enums;
using application.DTOs.Objects.Homework;
using application.Models;
using application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace application.Repositories.Queries
{
    public class QReport : IRepoReport
    {
        private readonly DataBaseContext _context = new();

        public List<HomeworkWithCategory> GetByFilters(Guid? id, DateTime? date, StatusEnum? status)
        {
            StatusEnum statusObtained = status ?? StatusEnum.Pending;
            DateTime dateObtain = (date ?? DateTime.Now).Date;
            
            List<Homework> query = _context.Homeworks
                .Include(h => h.Category)
                .Where(h =>
                        h.category_id == id &&
                        h.status == statusObtained &&
                        h.create_at.Date == dateObtain
                )
                .ToList();

            List<HomeworkWithCategory> result = Automapper.Mapper!.Map<List<HomeworkWithCategory>>(query);
            return result;
        }
    }
}
