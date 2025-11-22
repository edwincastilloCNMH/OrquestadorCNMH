using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface ISourceModelRepository : IDisposable
    {
        SourceModelEntity Create(SourceModelEntity entity);
        SourceModelEntity Update(SourceModelEntity entity);
        void Delete(int id);
        SourceModelEntity GetById(int id);
        IEnumerable<SourceModelEntity> GetAll();
    }
}
