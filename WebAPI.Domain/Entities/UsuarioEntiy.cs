namespace WebAPI.Domain.Entities
{
    public class UsuarioEntiy
    {
        public int Id { get; set; }
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
        public int EstadoId { get; set; }
        public bool IsActiveDirectoryUser { get; set; }

        // -----------------------------
        // Propiedades de navegación
        // -----------------------------

        public EstadoEntity Estado { get; set; }
        public DepartamentoEntity Departamento { get; set; }
        public MunicipioEntity Municipio { get; set; }
        public PaisEntity Pais { get; set; }
        public GeneroEntity Genero { get; set; }
        public NivelEducativoEntity NivelEducativo { get; set; }
        public TipoDocumentoEntity TipoDocumento { get; set; }
    }
}
