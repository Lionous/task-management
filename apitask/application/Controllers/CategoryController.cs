using application.DTOs.Objects.Category;
using application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController (IRepoCategory repoCategory) : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<CategoryDto> Create([FromBody] CreateCategory category)
        {
            CategoryDto newCategory = new CategoryDto
            {
                id = Guid.NewGuid(),
                name = category.name,
            };
            int result = repoCategory.Create(newCategory);

            if (result != 0) return Created("", "Creado correctamente.");
            return BadRequest("No se pudo crear la categoría.");
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<CategoryDto> GetById(Guid id)
        {
            CategoryDto category = repoCategory.GetById(id);
            return category;
        }
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<CategoryDto>> GetAll()
        {
            List<CategoryDto> category = repoCategory.GetAll();
            return category;
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateCategory category)
        {
            CategoryDto newCategory = new CategoryDto
            {
                id = id,
                name = category.name
            };

            int result = repoCategory.Update(newCategory);
            
            if (result != 0) return Ok("Actualizado con exito.");
            return BadRequest("No se pudo actualizar la categoría.");
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(Guid id)
        {
            int result = repoCategory.Delete(id);
            if (result != 0)
                return Ok("Eliminado con exito.");

            return NotFound("No se pudo eliminar");
        }
    }
}
