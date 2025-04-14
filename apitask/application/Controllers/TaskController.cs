using application.DTOs.Objects.Category;
using application.DTOs.Objects.Homework;
using application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController(IRepoHomework repoHomework) : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<HomeworkDto> Create([FromBody] CreateHomework homework)
        {
            HomeworkDto newHomework = new HomeworkDto
            {
                id = Guid.NewGuid(),
                title = homework.title,
                description = homework.description,
                status = homework.status,
                category_id = homework.category_id,
                create_at = DateTime.UtcNow
            };
            int result = repoHomework.Create(newHomework);

            if (result != 0) return Created("", "Creado correctamente.");
            return BadRequest("No se pudo crear la Tarea.");
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<HomeworkWithCategory> GetById(Guid id)
        {
            HomeworkWithCategory homework = repoHomework.GetIdWithCategory(id);
            return homework;
        }
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<HomeworkDto>> GetAll()
        {
            List<HomeworkDto> homework = repoHomework.GetAll();
            return homework;
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateHomework homework)
        {
            HomeworkDto newHomework = new HomeworkDto
            {
                id = id,
                title = homework.title,
                description = homework.description,
                status = homework.status,
                category_id = homework.category_id,
            };

            int result = repoHomework.Update(newHomework);
            
            if (result != 0) return Ok("Actualizado con exito.");
            return BadRequest("No se pudo actualizar la categoría.");
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(Guid id)
        {
            int result = repoHomework.Delete(id);
            if (result != 0)
                return Ok("Eliminado con exito.");

            return NotFound("No se pudo eliminar");
        }
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<HomeworkWithCategory>> GetWithCategories()
        {
            List<HomeworkWithCategory> listHomework = repoHomework.GetWithCategories();
            return Ok(listHomework);
        }
    }
}
