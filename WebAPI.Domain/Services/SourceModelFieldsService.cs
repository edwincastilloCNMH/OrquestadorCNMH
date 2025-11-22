using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class SourceModelFieldsService
    {
        private readonly ISourceModelFieldsRepository _SourceModelFieldsRepository;

        public SourceModelFieldsService(ISourceModelFieldsRepository SourceModelFieldsRepository)
        {
            _SourceModelFieldsRepository = SourceModelFieldsRepository;
        }

        public SourceModelFieldsEntity Create(SourceModelFieldsEntity entity)
        {
            try
            {
                return _SourceModelFieldsRepository.Create(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModelFields - Create: {ex.Message}");
                throw;
            }
        }

        public SourceModelFieldsEntity Update(SourceModelFieldsEntity entity)
        {
            try
            {
                return _SourceModelFieldsRepository.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModelFields - Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _SourceModelFieldsRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModelFields - Delete: {ex.Message}");
                throw;
            }
        }

        public SourceModelFieldsEntity GetById(int id)
        {
            try
            {
                return _SourceModelFieldsRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModelFields - GetById: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<SourceModelFieldsEntity> GetAll()
        {
            try
            {
                return _SourceModelFieldsRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModelFields - GetAll: {ex.Message}");
                throw;
            }
        }
    }
}
