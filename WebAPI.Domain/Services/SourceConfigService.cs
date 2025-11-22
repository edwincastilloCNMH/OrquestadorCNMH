using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class SourceConfigService
    {
        private readonly ISourceConfigRepository _SourceConfigRepository;

        public SourceConfigService(ISourceConfigRepository SourceConfigRepository)
        {
            _SourceConfigRepository = SourceConfigRepository;
        }

        public SourceConfigEntity Create(SourceConfigEntity entity)
        {
            try
            {
                return _SourceConfigRepository.Create(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceConfig - Create: {ex.Message}");
                throw;
            }
        }

        public SourceConfigEntity Update(SourceConfigEntity entity)
        {
            try
            {
                return _SourceConfigRepository.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceConfig - Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _SourceConfigRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceConfig - Delete: {ex.Message}");
                throw;
            }
        }

        public SourceConfigEntity GetById(int id)
        {
            try
            {
                return _SourceConfigRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceConfig - GetById: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<SourceConfigEntity> GetAll()
        {
            try
            {
                return _SourceConfigRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] SourceConfig - GetAll: {ex.Message}");
                throw;
            }
        }
    }
}
