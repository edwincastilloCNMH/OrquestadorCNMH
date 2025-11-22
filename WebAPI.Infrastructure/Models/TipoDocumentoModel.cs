using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("TipoDocumento", Schema = "dbo")]
    public class TipoDocumentoModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("TipoDocumento", TypeName = "varchar(100)")]
        public string TipoDocumento { get; set; }
    }
}
