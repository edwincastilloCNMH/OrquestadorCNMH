using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
    [Table("Genero", Schema = "dbo")]
    public class GeneroModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Genero", TypeName = "varchar(100)")]
        public string Genero { get; set; }
    }
}
