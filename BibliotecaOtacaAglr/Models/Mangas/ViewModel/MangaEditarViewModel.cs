﻿using BibliotecaOtacaAglr.Models.Generos.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Mangas.ViewModel
{
    public class MangaEditarViewModel
    {
        /// <summary>
        /// Identificador del manga
        /// </summary>
        [Required(ErrorMessage = "Manga requerido")]
        public int MangaId { get; set; }

        /// <summary>
        /// Nombre del manga
        /// </summary>
        [Required(ErrorMessage = "Nombre del manga requerido")]
        [MaxLength(100, ErrorMessage = "No mas de 100 caracteres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del manga
        /// </summary>
        [Required(ErrorMessage = "Descripcion requerida")]
        [StringLength(600, ErrorMessage = "Maximo {2} caracteres y minimo {1}", MinimumLength = 15)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de publicacion del anime
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha invalido. ejemplo de fecha: yyyy-MM-ddTHH:mm:ss")]
        public DateTime? Fecha_publicacion { get; set; }

        /// <summary>
        /// Portada del manga en arreglo de bytes
        /// </summary>
        public IFormFile Portada { get; set; }

        /// <summary>
        /// Relacion con los generos que tiene el manga
        /// </summary>
        public List<GeneroAsignadoViewModel> GenerosActivos { get; set; }

        /// <summary>
        /// Instancia para editar un manga en la base de datos
        /// </summary>
        public MangaEditarViewModel()
        {
            GenerosActivos = new List<GeneroAsignadoViewModel>();
        }
    }
}
