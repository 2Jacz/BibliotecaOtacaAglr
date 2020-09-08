using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using Microsoft.AspNetCore.Authorization;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Anime_Episodios.ViewModel;

namespace BibliotecaOtacaAglr.Controllers.Animes
{
    [Route("api/Anime/{animeId}/Episodio")]
    [Authorize]
    [ApiController]
    public class Anime_EpisodioController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public Anime_EpisodioController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Anime/{animeId}/Episodio/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Anime_Episodio>>> ListarAnime_Episodios(int? animeId)
        {
            if (animeId == null)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Proporcione un anime para ver sus capitulos" });
            }

            return Ok(await _context.Anime_Episodios.Where(ae => ae.AnimeId == animeId).Include(a => a.UrlServidores).Include(a => a.Anime).ToListAsync());
        }

        // GET: api/Anime/{animeId}/Episodio/5
        [HttpGet("{episodioid}")]
        [AllowAnonymous]
        public async Task<ActionResult<Anime_Episodio>> ObtenerAnime_Episodio(int? episodioid, double? numeroEpisodio, int? animeId)
        {
            //lista de episodios del anime
            List<Anime_Episodio> episodios = new List<Anime_Episodio>();
            Anime_EpisodioNavegacionEntreEpsViewModel episodios_navigation = new Anime_EpisodioNavegacionEntreEpsViewModel();

            //verifica si se pidio un id especifico
            if (episodioid == null)
            {
                //si no fue asi lo busca por el anime y el numero del capitulo
                if (numeroEpisodio == null || animeId == null)
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Episodio no encontrado" });
                }
                else
                {
                    //trae la lista de episodios del anime ordenado por numero de cap
                    episodios = await _context.Anime_Episodios.Where(ae => ae.AnimeId == animeId).Include(a => a.UrlServidores).Include(c => c.Anime).OrderBy(ae => ae.Numero_capitulo).ToListAsync();
                    episodios_navigation.Ep_actual = _context.Anime_Episodios.Where(e => e.Numero_capitulo == numeroEpisodio && e.AnimeId == animeId).First();
                }
            }
            else
            {
                //busca el cap especifico por id
                episodios_navigation.Ep_actual = await _context.Anime_Episodios.FirstAsync(e => e.ID == episodioid);

                //verifica si existe
                if (episodios_navigation.Ep_actual != null)
                {
                    //llena la lista con los caps del anime del capitulo buscado ordenado por numero de cap
                    episodios = await _context.Anime_Episodios.Where(ae => ae.AnimeId == episodios_navigation.Ep_actual.AnimeId).Include(c => c.Anime).OrderBy(ae => ae.Numero_capitulo).ToListAsync();
                }
            }

            if (episodios_navigation.Ep_actual == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Episodio no encontrado" });
            }

            //asiga en capitulo anterior y siguiente al cap buscado
            for (int i = 0; i < episodios.Count(); i++)
            {
                episodios_navigation.Ep_anterior = (i == 0) ? null : episodios[i - 1];
                episodios_navigation.Ep_siguiente = (i == episodios.Count() - 1) ? null : episodios[i + 1];

                if (episodios[i].ID == episodios_navigation.Ep_actual.ID) break;
            }

            episodios_navigation.Primer_ep = episodios.First().Numero_capitulo; //primer cap de la lista
            episodios_navigation.Ultimo_ep = episodios.Last().Numero_capitulo; //ultimo cap de la lista

            return Ok(episodios_navigation);
        }

        // PUT: api/Anime/{animeId}/Episodio/Modificar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Modificar/{id}")]
        public async Task<IActionResult> ModificarAnime_Episodio(int id, [FromBody] Anime_EpisodioEditarViewModel anime_Episodio)
        {
            if (id != anime_Episodio.Id)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Identificador de episodio invalido" });
            }

            Anime_Episodio editado = _context.Anime_Episodios.Include(a => a.UrlServidores).Include(e => e.Anime).FirstOrDefault(e => e.ID == anime_Episodio.Id);
            anime_Episodio.Anime = editado.Anime;

            editado.Titulo_capitulo = anime_Episodio.Titulo_capitulo;
            editado.Numero_capitulo = anime_Episodio.Numero_capitulo;
            editado.UrlServidores = anime_Episodio.UrlServidores;

            if (!string.IsNullOrEmpty(anime_Episodio.Nombre_Archivo))
            {
                editado.Nombre_archivo = anime_Episodio.Nombre_Archivo;
            }

            _context.Entry(anime_Episodio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Episodio modificado", Dato = editado });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!Anime_EpisodioExists(id))
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Episodio no encontrado" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, new ApiResponseFormat() { Estado = StatusCodes.Status304NotModified, Mensaje = ex.Message });
                }
            }
        }

        // POST: api/Anime/{animeId}/Episodio/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Anime_Episodio>> CrearAnime_Episodio([FromBody] Anime_Episodio anime_Episodio)
        {
            try
            {
                _context.Anime_Episodios.Add(anime_Episodio);
                await _context.SaveChangesAsync();
                return CreatedAtAction("ObtenerAnime_Episodio", new { id = anime_Episodio.ID }, anime_Episodio);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message, Dato = anime_Episodio });
            }
        }

        // DELETE: api/Anime/{animeId}/Episodio/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Anime_Episodio>> EliminarAnime_Episodio(int id)
        {
            var anime_Episodio = await _context.Anime_Episodios.FindAsync(id);
            if (anime_Episodio == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Episodio no encontrado" });
            }

            try
            {
                _context.Anime_Episodios.Remove(anime_Episodio);
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = "Episodio eliminado", Dato = anime_Episodio });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }




        private bool Anime_EpisodioExists(int id)
        {
            return _context.Anime_Episodios.Any(e => e.ID == id);
        }
    }
}
