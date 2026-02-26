using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] // La ruta será: api/empleados
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Inyectamos el contexto de la base de datos
        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/empleados (Para obtener la lista)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // POST: api/empleados (Para guardar un nuevo empleado)
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Empleado guardado con éxito", id = empleado.IdEmpleado });
        }

        // UPDATE: api/empleados
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
                return BadRequest();

            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Empleado actualizado");
        }

        // DELETE: api/empleados

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
                return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return Ok("Empleado eliminado");
        }
    }
}