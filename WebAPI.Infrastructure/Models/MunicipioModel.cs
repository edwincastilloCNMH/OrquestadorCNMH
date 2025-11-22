using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("Municipio", Schema = "dbo")]
    public class MunicipioModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Municipio", TypeName = "varchar(100)")]
        public string Municipio { get; set; }

        [Required]
        [Column("DepartamentoId")]
        public int DepartamentoId { get; set; }

        // Navegación
        public DepartamentoModel Departamento { get; set; }
    }
}
