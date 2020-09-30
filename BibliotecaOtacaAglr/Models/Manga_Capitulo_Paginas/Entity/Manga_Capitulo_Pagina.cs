using BibliotecaOtacaAglr.Models.Manga_Capitulos.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity
{
    /// <summary>
    /// Modelo con los datos de una pagina de manga que esta en la base de datos
    /// </summary>
    public class Manga_Capitulo_Pagina
    {
        /// <summary>
        /// Identificador de la pagina
        /// </summary>
        [Key]
        public int PaginaId { get; set; }

        /// <summary>
        /// Numero de pagina
        /// </summary>
        public double Numero_pagina { get; set; }

        /// <summary>
        /// La pagina en arreglo de bytes
        /// </summary>
        [Required]
        public byte[] Pagina { get; set; }

        /// <summary>
        /// Relacion con el capitulo de manga al que pertenece la pagina
        /// </summary>
        [Required]
        [ForeignKey("Manga_Capitulo")]
        public int Manga_CapituloId { get; set; }

        /// <summary>
        /// Instancia del capitulo de manga al que pertenece la pagina (o navegacion)
        /// </summary>
        public Manga_Capitulo Capitulo { get; set; }
    }
}
