using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;

namespace BibliotecaOtacaAglr.Controllers.Mangas
{
    [Route("api/Manga/{mangaid}/Capitulo/{capituloid}/Pagina")]
    [ApiController]
    [Authorize]
    public class Manga_Capitulo_PaginaController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public Manga_Capitulo_PaginaController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Manga/5/Capitulo/5/Paginas/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Manga_Capitulo_Pagina>>> ObtenerCapituloPaginas(int capituloid)
        {
            List<Manga_Capitulo_Pagina> paginas = await _context.Manga_Capitulo_Paginas.Where(p => p.CapituloId == capituloid).OrderBy(p => p.Numero_pagina).ToListAsync();
            return Ok(paginas);
        }

        // GET: api/Manga/5/Capitulo/5/Paginas
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> ObtenerPaginas(int id)
        {
            Manga_Capitulo_Pagina paginas = await _context.Manga_Capitulo_Paginas.FindAsync(id);

            if (paginas == null)
            {
                return NotFound("Recurso no encontrado");
            }

            return Ok(paginas);
        }

        // POST: api/Manga/5/Capitulo/5/Paginas/Agregar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> AgregarPaginas([FromBody][Bind("Nombre_pagina,CapituloId")] Manga_Capitulo_Pagina paginas, [FromForm][Bind("Pagina")] IFormFile pagina)
        {
            try
            {
                if (pagina == null)
                {
                    return BadRequest("Pagina imagen no encontrada");
                }

                MemoryStream ms = new MemoryStream();
                pagina.CopyTo(ms);
                paginas.Pagina = ms.ToArray();

                if (ModelState.IsValid)
                {
                    _context.Manga_Capitulo_Paginas.Add(paginas);
                    await _context.SaveChangesAsync();

                    return Ok(paginas);
                }

                return BadRequest("Datos invalidos");
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
            //return CreatedAtAction("GetPaginas", new { id = paginas.ID }, paginas);
        }

        // DELETE: api/Manga/5/Capitulo/5/Paginas/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> DeletePaginas(int id)
        {
            Manga_Capitulo_Pagina paginas = await _context.Manga_Capitulo_Paginas.Where(p => p.ID == id).FirstOrDefaultAsync();

            if (paginas == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "pagina invalida" });
            }

            try
            {
                _context.Manga_Capitulo_Paginas.Remove(paginas);
                await _context.SaveChangesAsync();

                return Ok(paginas);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }
    }
}
