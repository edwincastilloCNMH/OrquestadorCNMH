using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class MunicipioDTO
    {
        public int Id { get; set; }
        public string Municipio { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
    }
}
