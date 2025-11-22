using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class ModelTypeService
    {
        private readonly IModelTypeRepository _ModelTypeRepository;

        public ModelTypeService(IModelTypeRepository ModelTypeRepository)
        {
            _ModelTypeRepository = ModelTypeRepository;
        }

        public ModelTypeEntity Create(ModelTypeEntity entity)
        {
            try
            {
                return _ModelTypeRepository.Create(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] ModelType - Create: {ex.Message}");
                throw;
            }
        }

        public ModelTypeEntity Update(ModelTypeEntity entity)
        {
            try
            {
                return _ModelTypeRepository.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] ModelType - Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ModelTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] ModelType - Delete: {ex.Message}");
                throw;
            }
        }

        public ModelTypeEntity GetById(int id)
        {
            try
            {
                return _ModelTypeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] ModelType - GetById: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<ModelTypeEntity> GetAll()
        {
            try
            {
                return _ModelTypeRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] ModelType - GetAll: {ex.Message}");
                throw;
            }
        }
    }
}
