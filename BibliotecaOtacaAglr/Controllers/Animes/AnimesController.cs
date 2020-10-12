using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Animes.Entity;
using Microsoft.AspNetCore.Authorization;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.Entity.Paginador;
using BibliotecaOtacaAglr.Models.Animes.ViewModel;
using System.IO;
using BibliotecaOtacaAglr.Models.Generos.Entity;
using BibliotecaOtacaAglr.Helpers;

namespace BibliotecaOtacaAglr.Controllers.Animes
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AnimesController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public AnimesController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Animes/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Anime>>> ListarAnimes(string buscar, int? pagina)
        {
            List<Anime> ListaAnimes;

            if (!string.IsNullOrEmpty(buscar))
            {
                ListaAnimes = await _context.Animes.Where(a => a.Nombre.ToLower().Contains(buscar.ToLower())).ToListAsync();
            }
            else
            {
                ListaAnimes = await _context.Animes.ToListAsync();
            }

            Paginado animePaginador = new Paginado(ListaAnimes.Count(), pagina);
            AnimePaginadorViewModel animes = new AnimePaginadorViewModel()
            {
                Datos = ListaAnimes.Skip((animePaginador.PaginaActual - 1) * animePaginador.ObjetosPorPagina).Take(animePaginador.ObjetosPorPagina),
                Pagina = animePaginador
            };

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = buscar, Dato = animes });
        }

        // GET: api/Animes/5
        [HttpGet("{animeId}")]
        [AllowAnonymous]
        public async Task<ActionResult<Anime>> ObtenerAnime(int animeId)
        {
            Anime anime = await _context.Animes.Include(a => a.Generos).ThenInclude(g => g.Genero).Include(a => a.Episodios).FirstOrDefaultAsync(m => m.AnimeId == animeId);

            if (anime == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Anime no encontrado" });
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = anime });
        }

        // PUT: api/Animes/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> ModificarAnime(int id, [FromBody] AnimeEditarViewModel anime)
        {
            if (id != anime.AnimeId)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = $"Los Ids no coinciden {id} y {anime.AnimeId}" });
            }

            Anime modificado = await _context.Animes.Include(a => a.Generos).ThenInclude(g => g.Genero).Include(a => a.Episodios).FirstOrDefaultAsync(a => a.AnimeId == anime.AnimeId);
            modificado.Nombre = anime.Nombre;
            modificado.Numero_episodios = anime.Numero_episodios;
            modificado.Descripcion = anime.Descripcion;
            modificado.Fecha_publicacion = anime.Fecha_publicacion;

            string mensajePortadaInvalida = ".";
            if (anime.Portada != null)
            {
                if (FormFileExtensions.IsImage(anime.Portada))
                {
                    MemoryStream ms = new MemoryStream();
                    anime.Portada.CopyTo(ms);
                    modificado.Portada = ms.ToArray();
                } else
                {
                    mensajePortadaInvalida = " pero el formato de imagen invalido, se pondra la imagen de portada default.";
                }
            }

            await AniadirGeneros(modificado, anime.GenerosActivos.Where(ga => ga.Activo).Select(ga => ga.Genero).ToList());
            _context.Entry(modificado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Anime {modificado.Nombre} modificado exitosamente{mensajePortadaInvalida}", Dato = anime });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AnimeExists(id))
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = $"No se encontro ningun anime con el Id {id}" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = ex.Message });
                }
            }
        }

        // POST: api/Animes/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Anime>> CrearAnime([FromForm] AnimeCrearViewModel anime)
        {
            Anime nuevo = new Anime()
            {
                Descripcion = anime.Descripcion,
                Nombre = anime.Nombre,
                Numero_episodios = anime.Numero_episodios,
                Fecha_publicacion = anime.Fecha_publicacion,
                Fecha_subida = DateTime.UtcNow
            };

            await AniadirGeneros(nuevo, anime.GenerosActivos.Where(ga => ga.Activo).Select(ga => ga.Genero).ToList());

            if (anime.Portada != null)
            {
                if (FormFileExtensions.IsImage(anime.Portada))
                {
                    MemoryStream ms = new MemoryStream();
                    anime.Portada.CopyTo(ms);
                    nuevo.Portada = ms.ToArray();
                }
            }
            else
            {
                nuevo.Portada = System.IO.File.ReadAllBytes("./wwwroot/14671207_791293424306921_4080708202123646799_n.jpg");
            }

            try
            {
                _context.Animes.Add(nuevo);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, new ApiResponseFormat() { Estado = StatusCodes.Status201Created,Mensaje = $"Anime {nuevo.Nombre} creado exitosamente", Dato = nuevo });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status406NotAcceptable, Mensaje = ex.Message, Dato = ex.InnerException });
            }
        }

        // DELETE: api/Animes/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Anime>> EliminarAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Anime no encontrado" });
            }

            try
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Anime eliminado exitosamente", Dato = anime });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = ex.Message, Dato = anime });
            }
        }


        /// <summary>
        /// Verifica si el anime existe
        /// </summary>
        /// <param name="id">Identificador del anime</param>
        /// <returns>True si existe, false si no</returns>
        private bool AnimeExists(int id)
        {
            return _context.Animes.Any(e => e.AnimeId == id);
        }

        /// <summary>
        /// Asigna los generos al anime
        /// </summary>
        /// <param name="animes">Instancia del anime para asignarle los generos</param>
        /// <param name="generos_seleccionados">Lista con los IDs de los generos a relacionar</param>
        private async Task AniadirGeneros(Anime anime, List<Genero> generos_seleccionados)
        {
            if (generos_seleccionados.Count() > 0)
            {
                List<Anime_Genero> generos_agregar = new List<Anime_Genero>();

                foreach (Genero genero in generos_seleccionados)
                {
                    generos_agregar.Add(new Anime_Genero()
                    {
                        Anime = anime,
                        Genero = await _context.Generos.FindAsync(genero.GeneroId)
                    });
                }

                anime.Generos = generos_agregar;
            }
        }
    }
}
