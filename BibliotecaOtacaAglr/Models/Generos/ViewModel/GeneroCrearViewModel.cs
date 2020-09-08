using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.Generos.ViewModel
{
    public class GeneroCrearViewModel
    {
        [Required]
        public string Nombre { get; set; }
    }
}
