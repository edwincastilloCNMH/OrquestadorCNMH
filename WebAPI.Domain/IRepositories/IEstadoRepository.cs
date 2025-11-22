using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface IEstadoRepository : IDisposable
    {
        EstadoEntity Create(EstadoEntity entity);
        EstadoEntity Update(EstadoEntity entity);
        void Delete(int id);
        EstadoEntity GetById(int id);
        IEnumerable<EstadoEntity> GetAll();
    }
}
