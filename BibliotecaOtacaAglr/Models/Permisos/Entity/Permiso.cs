using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Permisos.Entity
{
    /// <summary>
    /// Modelo con los datos de permiso (Claims) que estan en la base de datos
    /// *Los claim se usaran como permisos
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Identificador del permiso
        /// </summary>
        [Key]
        public int PermisoId { get; set; }

        /// <summary>
        /// Nombre del permiso
        /// </summary>
        [Required]
        public string Tipo { get; set; }

        /// <summary>
        /// Descripcion del permiso
        /// </summary>
        [Required]
        public string Valor { get; set; }

        public Permiso() { }

        public Permiso(int permisoid, string tipo, string valor)
        {
            PermisoId = permisoid;
            Tipo = tipo;
            Valor = valor;
        }

        public Permiso(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
}
