using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Profiles;

namespace WebAPI.Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public EstadoRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(mapConfig);
        }

        public void Dispose() { }

        public EstadoEntity Create(EstadoEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<Estado>(entity);
                    context.Estado.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<EstadoEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Estado - Create: {ex.Message}");
                return new EstadoEntity();
            }
        }

        public EstadoEntity Update(EstadoEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.Estado.FirstOrDefault(x => x.Id == entity.Id);
                    if (existing == null)
                        return new EstadoEntity();

                    _mapper.Map(entity, existing);
                    context.SaveChanges();

                    return _mapper.Map<EstadoEntity>(existing);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Estado - Update: {ex.Message}");
                return new EstadoEntity();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.Estado.FirstOrDefault(x => x.Id == id);
                    if (existing != null)
                    {
                        context.Estado.Remove(existing);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Estado - Delete: {ex.Message}");
            }
        }

        public EstadoEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.Estado.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<EstadoEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Estado - GetById: {ex.Message}");
                return new EstadoEntity();
            }
        }

        public IEnumerable<EstadoEntity> GetAll()
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var list = context.Estado.ToList();
                    return _mapper.Map<IEnumerable<EstadoEntity>>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Estado - GetAll: {ex.Message}");
                return new List<EstadoEntity>();
            }
        }
    }
}
