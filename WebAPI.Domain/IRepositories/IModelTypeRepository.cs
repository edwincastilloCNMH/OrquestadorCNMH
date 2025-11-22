using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface IModelTypeRepository : IDisposable
    {
        ModelTypeEntity Create(ModelTypeEntity entity);
        ModelTypeEntity Update(ModelTypeEntity entity);
        void Delete(int id);
        ModelTypeEntity GetById(int id);
        IEnumerable<ModelTypeEntity> GetAll();
    }
}
