using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("Usuario", Schema = "dbo")]
    public class UsuarioModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nombres", TypeName = "varchar(100)")]
        public string Nombres { get; set; }

        [Required]
        [Column("Apellidos", TypeName = "varchar(100)")]
        public string Apellidos { get; set; }

        [Column("TipoDocumentoId")]
        public int? TipoDocumentoId { get; set; }

        [Column("NumDocumento", TypeName = "varchar(20)")]
        public string NumDocumento { get; set; }

        [Column("PaisId")]
        public int? PaisId { get; set; }

        [Column("MunicipioId")]
        public int? MunicipioId { get; set; }

        [Column("DepartamentoId")]
        public int? DepartamentoId { get; set; }

        [Column("GeneroId")]
        public int? GeneroId { get; set; }

        [Column("NivelEducativoId")]
        public int? NivelEducativoId { get; set; }

        [Column("Discapacidad")]
        public bool? Discapacidad { get; set; }

        [Column("FechaNacimiento", TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [Column("Correo", TypeName = "varchar(50)")]
        public string Correo { get; set; }

        [Column("Password", TypeName = "varchar(100)")]
        public string Password { get; set; }

        [Required]
        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Required]
        [Column("IsActiveDirectoryUser")]
        public bool IsActiveDirectoryUser { get; set; }

        [Column("Direccion", TypeName = "varchar(150)")]
        public string Direccion { get; set; }

        [Column("PoblacionInteresId")]
        public int? PoblacionInteresId { get; set; }

        [Column("AceptaCondiciones")]
        public bool? AceptaCondiciones { get; set; }

        [Column("ResetPasswordToken")]

        public string? ResetPasswordToken { get; set; }

        [Column("ResetTokenExpiration")]

        public DateTime? ResetTokenExpiration { get; set; }

        // -----------------------------
        // Propiedades de navegación
        // -----------------------------

        public Estado Estado { get; set; }
        public DepartamentoModel Departamento { get; set; }
        public MunicipioModel Municipio { get; set; }
        public PaisModel Pais { get; set; }
        public GeneroModel Genero { get; set; }
        public NivelEducativoModel NivelEducativo { get; set; }
        public TipoDocumentoModel TipoDocumento { get; set; }
        public PoblacionInteresModel PoblacionInteres { get; set; }
    }
}
