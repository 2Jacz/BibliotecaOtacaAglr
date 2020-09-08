using System;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Paginador
{
    /// <summary>
    /// Instancia para crear un paginador
    /// </summary>
    public class Paginado
    {
        /// <summary>
        /// Cantidad de objetos totales a dividir en paginas
        /// </summary>
        public int ObjetosTotales { get; private set; }
        /// <summary>
        /// Pagina actual dentro del pagindao
        /// </summary>
        public int PaginaActual { get; private set; }
        /// <summary>
        /// Se calcula las paginas totatel diviendo la cantidad de elementos entre los objetos a mostrar
        /// </summary>
        public int ObjetosPorPagina { get; private set; }
        /// <summary>
        /// Cantidad de paginas totates del paginado
        /// </summary>
        public int PaginasTotales { get; private set; }
        /// <summary>
        /// Primera pagina que mostrara el paginador
        /// </summary>
        public int PaginaInicial { get; private set; }
        /// <summary>
        /// Pagina final que mostrara el paginador
        /// </summary>
        public int PaginaFinal { get; private set; }

        /// <summary>
        /// Crea instancias de un paginador
        /// </summary>
        /// <param name="objetosTotales">Cantidad de objetos totales de la lista</param>
        /// <param name="Numpagina">Numero de la pagina a la que se quiere ir</param>
        /// <param name="objetosPorPagina">Objetos que se mostrarar por pagina</param>
        public Paginado(int objetosTotales, int? Numpagina, int objetosPorPagina = 10)
        {
            // calcula la cantidad de paginas diviendo los objetos ttotales entre la cantidad por pagina
            var paginasTotales = (int)Math.Ceiling((decimal)objetosTotales / (decimal)objetosPorPagina);
            // si no obtiene la pagina actual como parametro la asigna como 1 (la primera)
            // seniala el numero de pagina de las paginas totales en la que se encuetra actualmente
            var paginaActual = (Numpagina != null) ? (int)Numpagina : 1;
            // muestra el inicio del rango del paginador
            var paginaInicial = paginaActual - 5;
            // muestra el final del rango del paginador
            var paginaFinal = paginaActual + 5;

            // si el inicio del paginador es menor o igual a 0
            if (paginaInicial <= 0)
            {
                // la pagina final se calcula restando la pagina final (5) a la pagina inicial (-4) menos 1 que seria 0
                paginaFinal -= (paginaInicial - 1);

                // y la pagina inicial se vuelve 1 (la primera)
                paginaInicial = 1;
            }

            // si la pagina final supera el numero de paginas totales
            if (paginaFinal > paginasTotales)
            {
                // la pagina final se convierte en el numero de paginas totales
                paginaFinal = paginasTotales;

                // si la pagina final supera el 10
                if (paginaFinal > 10)
                {
                    // la pagina inicial seria la pagina final - 9 dejando un rango de 10 entre inicio y final del paginador
                    paginaInicial = paginaFinal - 9;
                }
            }

            // se asignan los valores al modelo
            ObjetosTotales = objetosTotales;
            PaginaActual = paginaActual;
            ObjetosPorPagina = objetosPorPagina;
            PaginasTotales = paginasTotales;
            PaginaInicial = paginaInicial;
            PaginaFinal = paginaFinal;
        }
    }
}
