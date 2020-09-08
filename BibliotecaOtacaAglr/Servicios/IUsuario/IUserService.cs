using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Servicios.IUsuario
{
    interface IUserService
    {
        Task<Usuario> GetByName(string id);
        Task<bool> ValidateToken(string id);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly BibliotecaOtakaBDContext _context;

        public UserService(UserManager<Usuario> userManager, BibliotecaOtakaBDContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Usuario> GetByName(string id)
        {
            return await _userManager.FindByNameAsync(id);
        }

        public async Task<bool> ValidateToken(string id)
        {
            try
            {
                var tokeninfo = await _context.UsuariosTokens.Where(ut => ut.UsuarioId == id).OrderByDescending(ut => ut.Fecha_Creacion).FirstOrDefaultAsync();

                if (tokeninfo == null) return false;
                    
                if (DateTime.UtcNow >= tokeninfo.Fecha_Expiracion)
                {
                    tokeninfo.Valido = false;

                    _context.UsuariosTokens.Update(tokeninfo);
                    await _context.SaveChangesAsync();
                }

                return tokeninfo.Valido;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
