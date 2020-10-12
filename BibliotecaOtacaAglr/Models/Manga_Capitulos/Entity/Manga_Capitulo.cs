using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using BibliotecaOtacaAglr.Models.Mangas.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity
{
    /// <summary>
    /// Modelo con los datos de un capitulo de manga como en la base de datos
    /// </summary>
    public class Manga_Capitulo
    {
        /// <summary>
        /// Identificador del capitulo
        /// </summary>
        [Key]
        public int CapituloId { get; set; }

        /// <summary>
        /// Nombre del capitulo
        /// </summary>
        [Required(ErrorMessage = "Nombre del capitulo requerido")]
        public string Nombre_capitulo { get; set; }

        /// <summary>
        /// Numero de capitulo
        /// </summary>
        [Required(ErrorMessage = "Numero del capitulo requerido")]
        [Display(Name = "Numero del capitulo")]
        public double Numero_capitulo { get; set; }

        /// <summary>
        /// Relacion con las paginas que contiene el capitulo
        /// </summary>
        public List<Manga_Capitulo_Pagina> Paginas { get; set; }

        /// <summary>
        /// Fecha de subida del ep
        /// </summary>
        public DateTime Fecha_subida { get; set; }

        /// <summary>
        /// Fecha de publicacion del ep
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime? Fecha_publicacion { get; set; }

        /// <summary>
        /// Relacion con el manga al que pertenece el capitulo
        /// </summary>
        [ForeignKey("Manga")]
        public int MangaId { get; set; }

        /// <summary>
        /// Instancia del manga al que pertenece el capitulo (o navegacion)
        /// </summary>
        public Manga Manga { get; set; }
        /// <summary>
        /// Instancia para enviar datos de un capitulo de manga en la base de datos
        /// </summary>
        public Manga_Capitulo()
        {
            Paginas = new List<Manga_Capitulo_Pagina>();
            Manga = new Manga();
            Fecha_subida = DateTime.UtcNow;
        }
    }
}
