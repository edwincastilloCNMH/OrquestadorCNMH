using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class PagedResultDTO<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
