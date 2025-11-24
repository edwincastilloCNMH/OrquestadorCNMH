using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class TipoDocumentoDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
    }
}
