namespace WebAPI.Domain.Entities
{
    public class ResponseEntity
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Serie { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string OriginDates { get; set; }
    }

    public class ConsultaResponseEntity
    {
        public string Origen { get; set; }
        public List<ResponseEntity> Respuesta { get; set; }
    }
}
