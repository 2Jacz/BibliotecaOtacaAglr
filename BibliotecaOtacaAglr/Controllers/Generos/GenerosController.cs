using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Generos.Entity;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using BibliotecaOtacaAglr.Models.Generos.ViewModel;

namespace BibliotecaOtacaAglr.Controllers.Generos
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public GenerosController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Generos/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Genero>>> ListaGeneros()
        {
            return Ok(await _context.Generos.Include(g => g.Animes).Include(g => g.Mangas).OrderBy(g => g.Nombre).ToListAsync());
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Genero>>> ObtenerGenero(int id)
        {
            return Ok(await _context.Generos.Where(g => g.ID == id).Include(g => g.Animes).Include(g => g.Mangas).FirstOrDefaultAsync());
        }

        // PUT: api/Generos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> EditarGeneros(int id, [FromBody][Bind("ID,Nombre")] Genero generos)
        {
            if (id != generos.ID)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Error al conseguir el genero deseado" });
            }

            if (_context.Generos.Any(g => g.Nombre.ToLower() == generos.Nombre.ToLower() && g.ID != id))
            {
                return Conflict(new ApiResponseFormat() { Estado = StatusCodes.Status409Conflict, Mensaje = $"El genero {generos.Nombre} ya existe." });
            }

            _context.Entry(generos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Genero {generos.Nombre} modificado exitosamente.", Dato = generos });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GenerosExists(id))
                {
                    return NotFound(new { result = "Error al modificar el genero deseado" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, new ApiResponseFormat { Estado = StatusCodes.Status304NotModified, Mensaje = ex.Message });
                }
            }
        }

        // POST: api/Generos/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        public async Task<ActionResult> AgregarGeneros([FromBody][Bind("Nombre")] GeneroCrearViewModel genero)
        {
            if (string.IsNullOrEmpty(genero.Nombre))
            {
                return BadRequest(new ApiResponseFormat { Estado = StatusCodes.Status400BadRequest, Mensaje = "Ingrese un nombre de genero" });
            }

            if (await _context.Generos.AnyAsync(g => g.Nombre.ToLower().Equals(genero.Nombre.ToLower())))
            {
                return Conflict(new ApiResponseFormat() { Estado = StatusCodes.Status409Conflict, Mensaje = $"El genero {genero.Nombre} ya existe." });
            }

            try
            {
                Genero nuevogenero = new Genero() { Nombre = genero.Nombre };
                await _context.Generos.AddAsync(nuevogenero);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Mensaje = $"Genero {genero.Nombre} creado exitosamente.", Dato = genero });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        // DELETE: api/Generos/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Genero>> DeleteGeneros(int id)
        {
            Genero generos = await _context.Generos.FindAsync(id);

            if (generos == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Genero no encontrado" });
            }

            try
            {
                _context.Generos.Remove(generos);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseFormat { Estado = StatusCodes.Status200OK, Mensaje = $"El genero {generos.Nombre} fue eliminado.", Dato = generos });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        private bool GenerosExists(int id)
        {
            return _context.Generos.Any(e => e.ID == id);
        }
    }
}
