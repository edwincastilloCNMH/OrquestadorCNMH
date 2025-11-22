using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
    public interface ISourceModelFieldsRepository : IDisposable
    {
        SourceModelFieldsEntity Create(SourceModelFieldsEntity entity);
        SourceModelFieldsEntity Update(SourceModelFieldsEntity entity);
        void Delete(int id);
        SourceModelFieldsEntity GetById(int id);
        IEnumerable<SourceModelFieldsEntity> GetAll();
    }
}
