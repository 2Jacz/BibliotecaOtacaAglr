namespace BibliotecaOtacaAglr.Models.Others.Entity.Permisos
{
    /// <summary>
    /// Determina si el permiso esta activo en el usuario
    /// </summary>
    public class PermisoAsignado
    {
        /// <summary>
        /// Nombre permiso
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Descripcion del permiso
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// True si el usuario tiene el permiso, False si no es asi
        /// </summary>
        public bool Activo { get; set; }
    }
}