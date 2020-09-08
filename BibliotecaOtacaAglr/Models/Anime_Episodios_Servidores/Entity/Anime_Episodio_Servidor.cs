using BibliotecaOtacaAglr.Models.Anime_Episodios.Entity;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaOtacaAglr.Models.Anime_Episodios_Servidores
{
    /// <summary>
    /// Modelo de las url en servidores donde esta el episodio de anime
    /// </summary>
    public class Anime_Episodio_Servidor
    {
        /// <summary>
        /// Identificador del episodio
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Url donde esta alojado el capitulo
        /// </summary>
        [Required(ErrorMessageResourceName = "URL requerida")]
        public string Enlace { get; set; }
        /// <summary>
        /// Relacion con el episodio al que pertenecera la url
        /// </summary>
        public int Anime_EpisodioId { get; set; }

        /// <summary>
        /// Instancia del episodio al que pertenecera la url (o navegacion)
        /// </summary>
        public Anime_Episodio Anime_Episodio { get; set; }
    }
}
