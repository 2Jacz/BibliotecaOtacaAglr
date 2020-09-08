using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Favorito.Entity;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOtacaAglr.Controllers.Animes
{
    [Route("api/Anime_Favorito")]
    [Authorize]
    [ApiController]
    public class Anime_FavoritoController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;
        private readonly UserManager<Usuario> _userManager;

        public Anime_FavoritoController(BibliotecaOtakaBDContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Anime_Favorito/Favoritos
        [HttpGet("Favoritos")]
        public async Task<ActionResult<IEnumerable<Anime_Favorito>>> ObtenerAnime_Favoritos()
        {
            try
            {
                Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

                if (correo != null)
                {
                    List<Anime_Favorito> favoritos = await _context.Anime_Favorito.Include(af => af.Anime).Where(ef => ef.Usuario.Email == correo.Value).ToListAsync();

                    return Ok(new ApiResponseFormat { Estado = StatusCodes.Status302Found, Dato = favoritos });
                }

                return StatusCode(StatusCodes.Status401Unauthorized, new ApiResponseFormat { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta opcion." });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponseFormat { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }

        // GET: api/Anime_Favorito/Favorito
        [HttpGet("Favorito")]
        public async Task<ActionResult<Anime_Favorito>> ObtenerAnime_Favorito([Bind("animeId")] int animeId)
        {
            try
            {
                Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

                if (correo != null)
                {
                    Anime_Favorito favorito = await _context.Anime_Favorito.Where(ef => ef.Usuario.Email == correo.Value && ef.AnimeID == animeId).FirstOrDefaultAsync();

                    if (favorito == null)
                    {
                        favorito = new Anime_Favorito()
                        {
                            Favorito = false
                        };
                    }

                    return Ok(new ApiResponseFormat { Estado = StatusCodes.Status302Found, Dato = favorito.Favorito });
                }

                return Unauthorized(new ApiResponseFormat { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta funcion." });
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult, new ApiResponseFormat { Estado = StatusCodes.Status404NotFound, Mensaje = ex.Message });
            }
        }

        // POST: api/Anime_Favorito/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Anime_Favorito>> CrearAnime_Favoritos([FromBody][Bind("animeId")] int animeId)
        {
            try
            {
                Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

                if (correo != null)
                {
                    Usuario usuario = await _userManager.FindByEmailAsync(correo.Value);

                    Anime_Favorito af = new Anime_Favorito()
                    {
                        Usuario = usuario,
                        Anime = _context.Animes.Find(animeId),
                        Favorito = true
                    };

                    _context.Add(af);
                    await _context.SaveChangesAsync();
                    return Ok(new ApiResponseFormat { Estado = StatusCodes.Status201Created, Mensaje = "Anime favorito agregado", Dato = af.Favorito });
                }

                return Unauthorized(new ApiResponseFormat { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta opcion." });

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(ex.HResult, new { Result = ex.HResult, Data = ex.Message });
            }
        }

        // DELETE: api/Anime_Favorito/Quitar/5
        [HttpDelete("Quitar")]
        public async Task<ActionResult<Anime_Favorito>> QuitarAnime_Favoritos([FromBody][Bind("animeId")] int animeId)
        {
            try
            {
                Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

                if (correo != null)
                {
                    Usuario usuario = await _userManager.FindByEmailAsync(correo.Value);
                    Anime_Favorito anime_Favorito = await _context.Anime_Favorito.Where(af => af.UsuarioId == usuario.Id && af.AnimeID == animeId).FirstOrDefaultAsync();

                    if (anime_Favorito == null)
                    {
                        return NotFound(new ApiResponseFormat { Estado = StatusCodes.Status404NotFound, Mensaje = "No esta en tu lista de favoritos" });
                    }

                    _context.Anime_Favorito.Remove(anime_Favorito);
                    await _context.SaveChangesAsync();
                    return Ok(new ApiResponseFormat { Estado = StatusCodes.Status200OK, Mensaje = "Anime favorito eliminado", Dato = false });
                }

                return Unauthorized(new ApiResponseFormat { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta opcion." });

            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult, new ApiResponseFormat { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }
    }
}