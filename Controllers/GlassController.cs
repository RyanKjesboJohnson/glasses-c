using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GlassesController : ControllerBase
{
    public GlassesController()
    {
    }

    //GET All action
   [HttpGet]
        public ActionResult<List<Glass>> GetAll() =>   
    GlassService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
        public ActionResult<Glass> Get(int id)
        {
            var glass = GlassService.Get(id);

            if(glass == null)
                return NotFound();

            return glass;
        }

    //POST action
    [HttpPost]
        public IActionResult Create(Glass glass)
        {            
            GlassService.Add(glass);
            return CreatedAtAction(nameof(Get), new { id = glass.Id }, glass);
        }
    // PUT action
    [HttpPut("{id}")]
        public IActionResult Update(int id, Glass glass)
        {
            if (id != glass.Id)
                return BadRequest();
                
            var existingGlass = GlassService.Get(id);
            if(existingGlass is null)
                return NotFound();
        
            GlassService.Update(glass);           
        
            return NoContent();
        }

    // DELETE action
    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var glass = GlassService.Get(id);
        
            if (glass is null)
                return NotFound();
            
            GlassService.Delete(id);
        
            return NoContent();
        }
}