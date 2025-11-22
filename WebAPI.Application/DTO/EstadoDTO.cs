using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


    public class EstadoCreateDTO
    {
        public string Nombre { get; set; }
    }

    public class EstadoUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
