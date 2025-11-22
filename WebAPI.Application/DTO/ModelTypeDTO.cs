using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class ModelTypeDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ModelTypeCreateDTO
    {
        public string Nombre { get; set; }
    }

    public class ModelTypeUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
