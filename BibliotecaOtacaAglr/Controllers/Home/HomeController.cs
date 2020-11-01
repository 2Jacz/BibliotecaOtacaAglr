using System;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.ViewModel.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOtacaAglr.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public HomeController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        [HttpGet("Anime")]
        public async Task<ActionResult> AnimeIndex()
        {
            try
            {
                HomeAnimeIndexViewModel inicio = new HomeAnimeIndexViewModel()
                {
                    AnimeUltimos12EpsAgregados = await _context.Anime_Episodios.OrderByDescending(ae => ae.Fecha_subida).Take(12)
                    .Select(ae => new HomeAnime_EpisodioViewModel() 
                    { 
                        Anime_portada = ae.Anime.Portada,
                        EpisodioId = ae.EpisodioId,
                        Nombre_anime = ae.Anime.Nombre,
                        Numero_episodio = ae.Numero_episodio
                    }
                    ).ToListAsync(),
                    Ultimos9AnimesAgregados = await _context.Animes.OrderByDescending(ae => ae.Fecha_subida).Take(9).Select(a => new HomeAnimeViewModel() 
                    { 
                        AnimeId = a.AnimeId,
                        Nombre = a.Nombre,
                        Portada = a.Portada
                    }).ToListAsync()
                };

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = inicio });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }

        [HttpGet("Manga")]
        public async Task<ActionResult> MangaIndex()
        {
            try
            {
                HomeMangaIndexViewModel inicio = new HomeMangaIndexViewModel()
                {
                    MangaUltimos12CapsAgregados = await _context.Manga_Capitulos.OrderByDescending(mc => mc.Fecha_subida).Take(12).Select(mc => new HomeManga_CapituloViewModel() { 
                        CapituloId = mc.CapituloId,
                        Manga_portada = mc.Manga.Portada,
                        Nombre_manga = mc.Manga.Nombre,
                        Numero_episodio = mc.Numero_capitulo
                    }).ToListAsync(),
                    Ultimos9MangasAgregados = await _context.Mangas.OrderByDescending(ae => ae.Fecha_subida).Take(9).Select(m => new HomeMangaViewModel() { 
                        MangaId = m.MangaId,
                        Nombre = m.Nombre,
                        Portada = m.Portada
                    }).ToListAsync()
                };
                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = inicio });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = ex.Message });
            }
        }
    }
}
