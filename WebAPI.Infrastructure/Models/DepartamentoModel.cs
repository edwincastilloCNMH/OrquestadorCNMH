using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("Departamento", Schema = "dbo")]
    public class DepartamentoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Departamento", TypeName = "varchar(100)")]
        public string Departamento { get; set; }

        [Required]
        [Column("PaisId")]
        public int PaisId { get; set; }

        // Navegación
        public PaisModel Pais { get; set; }
    }
}
