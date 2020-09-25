using System;
using System.Linq;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Others.ViewModel.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Index")]
        public ActionResult Index()
        {
            try
            {
                HomeIndexViewModel inicio = new HomeIndexViewModel()
                {
                    AnimeUltimos10EpsAgregados = _context.Anime_Episodios.OrderByDescending(ae => ae.Fecha_subida).Take(10).ToList(),
                    MangaUltimos10CapsAgregados = _context.Manga_Capitulos.OrderByDescending(ae => ae.Fecha_subida).Take(10).ToList(),
                    Ultimos7AnimesAgregados = _context.Animes.OrderByDescending(ae => ae.Fecha_subida).Take(7).ToList(),
                    Ultimos7MangasAgregados = _context.Mangas.OrderByDescending(ae => ae.Fecha_subida).Take(7).ToList()
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
