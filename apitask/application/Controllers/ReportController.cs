using application.DTOs.Enums;
using application.DTOs.Objects.Homework;
using application.DTOs.Others;
using application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportController (IRepoReport repoReport) : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<HomeworkWithCategory>> GetByFilters(
            [FromQuery] Guid? categoryId,
            [FromQuery] DateTime? date,
            [FromQuery] StatusEnum? status)
        {
            List<HomeworkWithCategory> listHomework = repoReport.GetByFilters(categoryId, date, status);
            return Ok(listHomework);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<object> Statistics()
        {
            HomeworkStatistics stats = repoReport.GetStatistics();
            return Ok(stats);
        }
    }
}
