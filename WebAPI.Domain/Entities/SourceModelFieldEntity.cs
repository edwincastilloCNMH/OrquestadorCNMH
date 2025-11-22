using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class SourceModelFieldsEntity
    {
        public int Id { get; set; }
        public int SourceModelId { get; set; }
        public string NombreCampo { get; set; }
        public string CampoOrigen { get; set; }
        public int EstadoId { get; set; }

        public SourceModelEntity SourceModel { get; set; }
        public EstadoEntity Estado { get; set; }
    }
}
