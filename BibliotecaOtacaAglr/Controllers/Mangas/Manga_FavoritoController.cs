using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Favorito.Entity;
using Microsoft.AspNetCore.Identity;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using System.Security.Claims;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaOtacaAglr.Controllers.Mangas
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manga_FavoritoController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;
        private readonly UserManager<Usuario> _userManager;

        public Manga_FavoritoController(BibliotecaOtakaBDContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Manga_Favorito/Favoritos
        [HttpGet("Favoritos")]
        public async Task<ActionResult<IEnumerable<Manga_Favorito>>> GetManga_Favoritos()
        {
            Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

            if (correo != null)
            {
                List<Manga_Favorito> favoritos = await _context.Manga_Favorito.Include(af => af.Manga).Where(ef => ef.Usuario.Email == correo.Value).ToListAsync();

                return Ok(favoritos);
            }

            return Unauthorized(new ApiResponseFormat() { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta opcion." });
        }

        // GET: api/Manga_Favorito/Favorito
        [HttpGet("{mangaId}/Favorito")]
        public async Task<ActionResult<Manga_Favorito>> GetManga_Favorito(int mangaId)
        {
            Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

            if (correo != null)
            {
                Manga_Favorito favorito = await _context.Manga_Favorito.Where(ef => ef.Usuario.Email == correo.Value && ef.MangaID == mangaId).FirstOrDefaultAsync();

                if (favorito == null)
                {
                    favorito = new Manga_Favorito()
                    {
                        Favorito = false
                    };
                }

                return Ok(favorito.Favorito);
            }

            return Unauthorized(new ApiResponseFormat() { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta funcion." });
        }

        // POST: api/Manga_Favorito
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Agregar/{mangaId}")]
        public async Task<ActionResult<Manga_Favorito>> PostManga_Favoritos(int mangaId)
        {
            Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

            if (correo != null)
            {
                Usuario usuario = await _userManager.FindByEmailAsync(correo.Value);
                Manga manga = _context.Mangas.Find(mangaId);

                Manga_Favorito af = new Manga_Favorito()
                {
                    Usuario = usuario,
                    Manga = manga,
                    Favorito = true
                };

                try
                {
                    _context.Add(af);
                    await _context.SaveChangesAsync();
                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Mensaje = $"{manga.Nombre} agregado a favoritos", Dato = af.Favorito });
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
                }
            }

            return Unauthorized(new { Result = StatusCodes.Status401Unauthorized, Data = "Inicie sesion para usar esta opcion." });
        }

        // DELETE: api/Manga_Favorito/5
        [HttpDelete("Quitar/{mangaId}")]
        public async Task<ActionResult<Manga_Favorito>> DeleteManga_Favoritos(int mangaId)
        {
            Claim correo = User.Claims.FirstOrDefault(c => c.Type == "Email");

            if (correo != null)
            {
                Usuario usuario = await _userManager.FindByEmailAsync(correo.Value);
                Manga_Favorito manga_Favorito = await _context.Manga_Favorito.Where(af => af.UsuarioId == usuario.Id && af.MangaID == mangaId).FirstOrDefaultAsync();

                if (manga_Favorito == null)
                {
                    return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "No esta en tu lista de favoritos" });
                }

                try
                {
                    _context.Manga_Favorito.Remove(manga_Favorito);
                    await _context.SaveChangesAsync();
                    return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Mensaje = $"Manga {manga_Favorito.Manga.Nombre} eliminado de favoritos" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
                }
            }

            return Unauthorized(new ApiResponseFormat() { Estado = StatusCodes.Status401Unauthorized, Mensaje = "Inicie sesion para usar esta opcion." });
        }
    }
}
