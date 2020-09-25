using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using BibliotecaOtacaAglr.Models.Manga_Capitulos.ViewModel;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaOtacaAglr.Controllers.Mangas
{
    [Route("api/Manga/{mangaid}/Capitulos")]
    [Authorize]
    [ApiController]
    public class Manga_CapituloController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public Manga_CapituloController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Manga/5/Capitulos/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Manga_Capitulo>>> GetManga_Capitulos(int mangaid)
        {
            Manga_CapituloViewModel capitulos = new Manga_CapituloViewModel()
            {
                Manga = await _context.Mangas.FindAsync(mangaid),
                Capitulos = await _context.Manga_Capitulos.Where(mc => mc.MangaId == mangaid).ToListAsync()
            };

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = capitulos });
        }

        // GET: api/Manga/5/Capitulos/5
        [HttpGet("{capituloid}")]
        [AllowAnonymous]
        public async Task<ActionResult<Manga_Capitulo>> ObtenerManga_Capitulo(int? capituloid, int? numcap, int? mangaId)
        {
            List<Manga_Capitulo> capitulos = new List<Manga_Capitulo>();
            Manga_CapituloNavegacionViewModel capitulos_navigation = new Manga_CapituloNavegacionViewModel();

            if (capituloid == null)
            {
                if (mangaId == null)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Manga invalido" });
                }
                if (numcap == null)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Capitulo invalido" });
                }
                else
                {
                    capitulos = await _context.Manga_Capitulos.Where(m => m.MangaId == mangaId).Include(c => c.Manga).Include(c => c.Paginas).OrderBy(e => e.Numero_capitulo).ToListAsync();
                    capitulos_navigation.Cap_actual = capitulos.Where(e => e.Numero_capitulo == numcap).First();

                    if (capitulos_navigation.Cap_actual == null)
                    {
                        return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Capitulo no encintrado" });
                    }
                }
            }
            else
            {
                capitulos = await _context.Manga_Capitulos.Where(m => m.MangaId == mangaId).Include(c => c.Manga).Include(c => c.Paginas).OrderBy(e => e.Numero_capitulo).ToListAsync();
                capitulos_navigation.Cap_actual = capitulos.FirstOrDefault(c => c.CapituloId == capituloid);

                if (capitulos_navigation == null || capitulos_navigation.Cap_actual == null)
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Capitulo no encontrado" });
                }
            }

            capitulos_navigation.Cap_actual.Paginas = capitulos_navigation.Cap_actual.Paginas.OrderBy(p => p.Numero_pagina).ToList();

            for (int i = 0; i < capitulos.Count(); i++)
            {
                capitulos_navigation.Cap_anterior = (i == 0) ? null : capitulos[i - 1];
                capitulos_navigation.Cap_siguiente = (i == capitulos.Count() - 1) ? null : capitulos[i + 1];

                if (capitulos[i].CapituloId == capitulos_navigation.Cap_actual.CapituloId) break;
            }

            capitulos_navigation.Cap_inicial = capitulos.First().Numero_capitulo;
            capitulos_navigation.Cap_final = capitulos.Last().Numero_capitulo;

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = capitulos_navigation });
        }

        // PUT: api/Manga/5/Capitulos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> EditarManga_Capitulo(int? id, [FromBody] Manga_CapituloEditarViewModel manga)
        {
            if (id == null)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Capitulo invalido" });
            }

            Manga_Capitulo editado = _context.Manga_Capitulos.Find(id);
            editado.Nombre_capitulo = manga.Nombre_capitulo;
            editado.Numero_capitulo = manga.Numero_capitulo;
            editado.Fecha_publicacion = manga.Fecha_publicacion;
            editado.Paginas = manga.Paginas;

            _context.Entry(editado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Capitulo {editado.Nombre_capitulo} editado con exito", Dato = editado });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Manga_CapituloExists((int)id))
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = "Capitulo invalido" });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
                }
            }
        }

        // POST: api/Manga/5/Capitulo/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Manga_Capitulo>> AgregarManga_Capitulo(int mangaid, [FromBody] Manga_CapituloCrearViewModel manga)
        {
            Manga_Capitulo newmangacap = new Manga_Capitulo()
            {
                Nombre_capitulo = manga.Nombre_capitulo,
                Numero_capitulo = manga.Numero_capitulo,
                Fecha_publicacion = manga.Fecha_publicacion,
                Fecha_subida = DateTime.UtcNow,
                Manga = await _context.Mangas.FindAsync(mangaid),
                MangaId = manga.MangaId
            };

            try
            {
                _context.Manga_Capitulos.Add(newmangacap);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Dato = newmangacap });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        // DELETE: api/Manga/5/Capitulo/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Manga_Capitulo>> DeleteManga_Capitulo(int id)
        {
            var manga_Capitulo = await _context.Manga_Capitulos.FindAsync(id);
            if (manga_Capitulo == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Capitulo invalido" });
            }

            try
            {
                _context.Manga_Capitulos.Remove(manga_Capitulo);
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Capitulo eliminado", Dato = manga_Capitulo });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        private bool Manga_CapituloExists(int id)
        {
            return _context.Manga_Capitulos.Any(e => e.CapituloId == id);
        }
    }
}
