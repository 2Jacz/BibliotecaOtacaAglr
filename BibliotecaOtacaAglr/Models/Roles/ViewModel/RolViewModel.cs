using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    public class RolViewModel
    {
        public IdentityRole Rol { get; set; }
        public IEnumerable<Usuario> Asignados { get; set; }
        public IEnumerable<Usuario> NoAsignados { get; set; }

        public IList<Claim> Permisos { get; set; }

        public RolViewModel()
        {
            Permisos = new List<Claim>();
        }
    }
}
