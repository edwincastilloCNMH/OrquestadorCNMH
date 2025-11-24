using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Models
{
    [Table("PoblacionInteres", Schema = "dbo")]
    public class PoblacionInteresModel
    {
        [Key]
        public int Id { get; set; }

        [Column("PoblacionInteres")]
        public string PoblacionInteres { get; set; }
    }
}
