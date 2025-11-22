namespace WebAPI.Application.Models
{
    public class UsuarioRequest
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string NumDocumento { get; set; }
        public int? PaisId { get; set; }
        public int? MunicipioId { get; set; }
        public int? DepartamentoId { get; set; }
        public int? GeneroId { get; set; }
        public int? NivelEducativoId { get; set; }
        public bool? Discapacidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
