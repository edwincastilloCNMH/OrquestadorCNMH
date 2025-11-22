using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
    public class EstadoService
    {
        private readonly IEstadoRepository _EstadoRepository;

        public EstadoService(IEstadoRepository EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }

        public EstadoEntity Create(EstadoEntity entity)
        {
            try
            {
                return _EstadoRepository.Create(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] Estado - Create: {ex.Message}");
                throw;
            }
        }

        public EstadoEntity Update(EstadoEntity entity)
        {
            try
            {
                return _EstadoRepository.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] Estado - Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _EstadoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] Estado - Delete: {ex.Message}");
                throw;
            }
        }

        public EstadoEntity GetById(int id)
        {
            try
            {
                return _EstadoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] Estado - GetById: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<EstadoEntity> GetAll()
        {
            try
            {
                return _EstadoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Domain Service Error] Estado - GetAll: {ex.Message}");
                throw;
            }
        }
    }
}
