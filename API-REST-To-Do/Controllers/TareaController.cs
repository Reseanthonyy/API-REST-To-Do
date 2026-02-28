using API_REST_To_Do.Data;
using API_REST_To_Do.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST_To_Do.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TareaController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetAll()
        {
            return await _context.Tareas.ToListAsync();
        }

        //GET: api/tareas/5
        [HttpGet]
        public async Task<ActionResult<Tarea>> GetById(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
                return NotFound();
            return tarea;

        }

        //POST: api/tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> Create(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tarea.Id }, tarea);
        }

        //PUT: api/tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tarea tarea)
        {
            if(id != tarea.Id)
                return BadRequest();

            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return NotFound();

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
