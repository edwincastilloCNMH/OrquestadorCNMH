using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("NivelEducativo", Schema = "dbo")]
    public class NivelEducativoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("NivelEducativo", TypeName = "varchar(150)")]
        public string NivelEducativo { get; set; }
    }
}
