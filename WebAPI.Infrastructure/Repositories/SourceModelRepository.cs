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
    public class SourceModelRepository : ISourceModelRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public SourceModelRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });

            _mapper = new Mapper(mapConfig);
        }

        public void Dispose() { }

        public SourceModelEntity Create(SourceModelEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<SourceModel>(entity);
                    context.SourceModel.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<SourceModelEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModel - Create: {ex.Message}");
                return new SourceModelEntity();
            }
        }

        public SourceModelEntity Update(SourceModelEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModel.FirstOrDefault(x => x.Id == entity.Id);
                    if (model == null)
                        return new SourceModelEntity();

                    _mapper.Map(entity, model);
                    context.SaveChanges();

                    return _mapper.Map<SourceModelEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModel - Update: {ex.Message}");
                return new SourceModelEntity();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModel.FirstOrDefault(x => x.Id == id);
                    if (model != null)
                    {
                        context.SourceModel.Remove(model);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModel - Delete: {ex.Message}");
            }
        }

        public SourceModelEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModel.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<SourceModelEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModel - GetById: {ex.Message}");
                return new SourceModelEntity();
            }
        }

        public IEnumerable<SourceModelEntity> GetAll()
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var list = context.SourceModel.ToList();
                    return _mapper.Map<IEnumerable<SourceModelEntity>>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModel - GetAll: {ex.Message}");
                return new List<SourceModelEntity>();
            }
        }
    }
}
