namespace BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse
{
    public class ApiResponseFormat
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public object Dato { get; set; }

        public ApiResponseFormat() { }

        public ApiResponseFormat(int estado)
        {
            Estado = estado;
        }

        public ApiResponseFormat(int estado, string mensaje)
        {
            Estado = estado;
            Mensaje = mensaje;
        }

        public ApiResponseFormat(int estado, object dato)
        {
            Estado = estado;
            Dato = dato;
        }

        public ApiResponseFormat(int estado, string mensaje, object dato)
        {
            Estado = estado;
            Mensaje = mensaje;
            Dato = dato;
        }
    }
}
