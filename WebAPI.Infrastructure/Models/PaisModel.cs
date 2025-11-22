using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("Pais", Schema = "dbo")]
    public class PaisModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Pais", TypeName = "varchar(100)")]
        public string Pais { get; set; }
    }
}
