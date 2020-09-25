using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using BibliotecaOtacaAglr.Models.Others.Entity.Paginador;
using BibliotecaOtacaAglr.Models.Mangas.ViewModel;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Generos.Entity;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaOtacaAglr.Controllers.Mangas
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MangasController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public MangasController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Mangas/Lista
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<Manga>>> ListarMangas(string buscar, int? pagina)
        {
            List<Manga> ListaMangas;

            if (!string.IsNullOrEmpty(buscar))
            {
                ListaMangas = await _context.Mangas.Where(a => a.Nombre.Contains(buscar)).ToListAsync();
            }
            else
            {
                ListaMangas = await _context.Mangas.ToListAsync();
            }

            Paginado animePaginador = new Paginado(ListaMangas.Count(), pagina);
            MangaPaginadorViewModel mangaspaginados = new MangaPaginadorViewModel()
            {
                Datos = ListaMangas.Skip((animePaginador.PaginaActual - 1) * animePaginador.ObjetosPorPagina).Take(animePaginador.ObjetosPorPagina),
                Pagina = animePaginador
            };

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = mangaspaginados });
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerManga(int? mangaId)
        {
            if (mangaId == null)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Manga invalido" });
            }

            Manga mangas = await _context.Mangas.Include(m => m.Generos).ThenInclude(g => g.Genero).Include(m => m.Capitulos).FirstOrDefaultAsync(m => m.MangaId == mangaId);

            if (mangas == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Manga no encontrado" });
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = mangas });
        }

        // PUT: api/Mangas/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Editar/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(int mangaId, [FromBody] MangaEditarViewModel mangas)
        {
            if (mangaId != mangas.mangaId)
            {
                return NotFound(new ApiResponseFormat() { });
            }

            Manga editado = await _context.Mangas.Include(m => m.Generos).ThenInclude(g => g.Genero).Include(m => m.Capitulos).FirstOrDefaultAsync(a => a.MangaId == mangas.mangaId);
            editado.Nombre = mangas.Nombre;
            editado.Descripcion = mangas.Descripcion;
            editado.Fecha_publicacion = mangas.Fecha_publicacion;

            if (mangas.Portada != null)
            {
                MemoryStream ms = new MemoryStream();
                mangas.Portada.CopyTo(ms);
                editado.Portada = ms.ToArray();
            }

            await AniadirGeneros(editado, mangas.GenerosActivos.Where(ga => ga.Activo).Select(ga => ga.Genero).ToList());

            try
            {
                _context.Update(editado);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Manga {editado.Nombre} modificado con exito", Dato = editado });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!MangaExists(mangas.mangaId))
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Manga invalido" });
                }
                else
                {
                    return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
                }
            }
        }

        // POST: api/Mangas/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        [AllowAnonymous]
        public async Task<IActionResult> AgregarManga([FromBody] MangaCrearViewModel mangas)
        {
            Manga newmanga = new Manga()
            {
                Descripcion = mangas.Descripcion,
                Nombre = mangas.Nombre,
                Fecha_publicacion = mangas.Fecha_publicacion,
                Fecha_subida = DateTime.UtcNow
            };

            if (mangas.Portada != null)
            {
                MemoryStream ms = new MemoryStream();
                mangas.Portada.CopyTo(ms);
                newmanga.Portada = ms.ToArray();
            }
            else
            {
                newmanga.Portada = System.IO.File.ReadAllBytes("./wwwroot/14671207_791293424306921_4080708202123646799_n.jpg.jpg");
            }

            await AniadirGeneros(newmanga, mangas.GenerosActivos.Where(ga => ga.Activo).Select(ga => ga.Genero).ToList());

            try
            {
                _context.Add(newmanga);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Mensaje = $"Manga {newmanga.Nombre} agregado exitosamente", Dato = newmanga });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        // DELETE: api/Mangas/5
        [HttpDelete("Eliminar/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Manga>> DeleteManga(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Manga invalido" });
            }

            try
            {
                _context.Mangas.Remove(manga);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Manga {manga.Nombre} eliminado con exito", Dato = manga });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }



        /// <summary>
        /// Asigna los generos al manga
        /// </summary>
        /// <param name="manga">Instancia del anime para asignarle los generos</param>
        /// <param name="generos_seleccionados">Lista con los IDs de los generos a relacionar</param>
        private async Task AniadirGeneros(Manga manga, List<Genero> generos_seleccionados)
        {
            if (generos_seleccionados.Count() > 0)
            {
                List<Manga_Genero> generos_agregar = new List<Manga_Genero>();

                foreach (Genero genero in generos_seleccionados)
                {
                    generos_agregar.Add(new Manga_Genero()
                    {
                        Manga = manga,
                        Genero = await _context.Generos.FindAsync(genero.GeneroId)
                    });
                }

                manga.Generos = generos_agregar;
            }
        }

        private bool MangaExists(int id)
        {
            return _context.Mangas.Any(e => e.MangaId == id);
        }
    }
}
