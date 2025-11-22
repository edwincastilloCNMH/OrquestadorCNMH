using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class ModelTypeEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }

        public EstadoEntity Estado { get; set; }
    }
}
