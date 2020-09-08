using System.Collections.Generic;
using System.Security.Claims;

namespace BibliotecaOtacaAglr.Models.Roles.ViewModel
{
    public class RolPermisoEditarViewModel
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        /// <summary>
        /// Lista con los permisos a mostrar
        /// </summary>
        public IList<Claim> Permisos { get; set; }

        public RolPermisoEditarViewModel()
        {
            Permisos = new List<Claim>();
        }
    }
}
