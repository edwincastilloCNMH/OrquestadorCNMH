using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class SourceModelDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ModelTypeId { get; set; }
    }

    public class SourceModelCreateDTO
    {
        public string Nombre { get; set; }
        public int ModelTypeId { get; set; }
    }

    public class SourceModelUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ModelTypeId { get; set; }
    }

}
