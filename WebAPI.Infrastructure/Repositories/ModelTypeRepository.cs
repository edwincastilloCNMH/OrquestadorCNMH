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
    public class ModelTypeRepository : IModelTypeRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public ModelTypeRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });

            _mapper = new Mapper(mapConfig);
        }

        public void Dispose() { }

        public ModelTypeEntity Create(ModelTypeEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<ModelType>(entity);
                    context.ModelType.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<ModelTypeEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ModelType - Create: {ex.Message}");
                return new ModelTypeEntity();
            }
        }

        public ModelTypeEntity Update(ModelTypeEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.ModelType.FirstOrDefault(x => x.Id == entity.Id);
                    if (model == null)
                        return new ModelTypeEntity();

                    _mapper.Map(entity, model);
                    context.SaveChanges();
                    return _mapper.Map<ModelTypeEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ModelType - Update: {ex.Message}");
                return new ModelTypeEntity();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.ModelType.FirstOrDefault(x => x.Id == id);
                    if (model != null)
                    {
                        context.ModelType.Remove(model);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ModelType - Delete: {ex.Message}");
            }
        }

        public ModelTypeEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.ModelType.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<ModelTypeEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ModelType - GetById: {ex.Message}");
                return new ModelTypeEntity();
            }
        }

        public IEnumerable<ModelTypeEntity> GetAll()
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var list = context.ModelType.ToList();
                    return _mapper.Map<IEnumerable<ModelTypeEntity>>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] ModelType - GetAll: {ex.Message}");
                return new List<ModelTypeEntity>();
            }
        }
    }
}
