using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class SourceModelService
    {
        private readonly ISourceModelRepository _SourceModelRepository;

        public SourceModelService(ISourceModelRepository SourceModelRepository)
        {
            _SourceModelRepository = SourceModelRepository;
        }

        public SourceModelEntity Create(SourceModelEntity entity)
        {
            try
            {
                return _SourceModelRepository.Create(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModel - Create: {ex.Message}");
                throw;
            }
        }

        public SourceModelEntity Update(SourceModelEntity entity)
        {
            try
            {
                return _SourceModelRepository.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModel - Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _SourceModelRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModel - Delete: {ex.Message}");
                throw;
            }
        }

        public SourceModelEntity GetById(int id)
        {
            try
            {
                return _SourceModelRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModel - GetById: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<SourceModelEntity> GetAll()
        {
            try
            {
                return _SourceModelRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceModel - GetAll: {ex.Message}");
                throw;
            }
        }
    }
}
