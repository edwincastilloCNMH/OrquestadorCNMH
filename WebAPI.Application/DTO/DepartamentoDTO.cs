using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class DepartamentoDTO
    {
        public int Id { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public int PaisId { get; set; }
    }
}
