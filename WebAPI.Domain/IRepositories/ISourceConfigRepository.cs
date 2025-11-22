using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface ISourceConfigRepository : IDisposable
    {
        SourceConfigEntity Create(SourceConfigEntity entity);
        SourceConfigEntity Update(SourceConfigEntity entity);
        void Delete(int id);
        SourceConfigEntity GetById(int id);
        IEnumerable<SourceConfigEntity> GetAll();
    }
}
