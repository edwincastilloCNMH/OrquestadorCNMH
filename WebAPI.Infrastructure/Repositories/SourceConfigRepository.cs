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
    public class SourceConfigRepository : ISourceConfigRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public SourceConfigRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });

            _mapper = new Mapper(mapConfig);
        }

        public void Dispose()
        {
            // Si en algún momento inyectas el contexto o algo disposable, se limpia aquí.
        }

        public SourceConfigEntity Create(SourceConfigEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<SourceConfig>(entity);

                    context.SourceConfig.Add(model);
                    context.SaveChanges();

                    return _mapper.Map<SourceConfigEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceConfig - Create: {ex.Message}");
                return new SourceConfigEntity();
            }
        }

        public SourceConfigEntity Update(SourceConfigEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.SourceConfig.FirstOrDefault(x => x.Id == entity.Id);

                    if (existing == null)
                    {
                        // No existe el registro
                        return new SourceConfigEntity();
                    }

                    // Mapear los cambios desde la Entity hacia el modelo de EF
                    _mapper.Map(entity, existing);

                    context.SaveChanges();

                    return _mapper.Map<SourceConfigEntity>(existing);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceConfig - Update: {ex.Message}");
                return new SourceConfigEntity();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.SourceConfig.FirstOrDefault(x => x.Id == id);

                    if (existing != null)
                    {
                        context.SourceConfig.Remove(existing);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceConfig - Delete: {ex.Message}");
                // Si quieres, aquí podrías relanzar la excepción o manejar un log más elaborado
            }
        }

        public SourceConfigEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceConfig.FirstOrDefault(x => x.Id == id);

                    if (model == null)
                    {
                        return new SourceConfigEntity();
                    }

                    return _mapper.Map<SourceConfigEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceConfig - GetById: {ex.Message}");
                return new SourceConfigEntity();
            }
        }

        public IEnumerable<SourceConfigEntity> GetAll()
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var list = context.SourceConfig.ToList();
                    return _mapper.Map<IEnumerable<SourceConfigEntity>>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceConfig - GetAll: {ex.Message}");
                return new List<SourceConfigEntity>();
            }
        }
    }
}
