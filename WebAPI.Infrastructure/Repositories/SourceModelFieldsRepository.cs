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
    public class SourceModelFieldsRepository : ISourceModelFieldsRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public SourceModelFieldsRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });

            _mapper = new Mapper(mapConfig);
        }

        public void Dispose() { }

        public SourceModelFieldsEntity Create(SourceModelFieldsEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<SourceModelFields>(entity);
                    context.SourceModelFields.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<SourceModelFieldsEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModelFields - Create: {ex.Message}");
                return new SourceModelFieldsEntity();
            }
        }

        public SourceModelFieldsEntity Update(SourceModelFieldsEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModelFields.FirstOrDefault(x => x.Id == entity.Id);
                    if (model == null)
                        return new SourceModelFieldsEntity();

                    _mapper.Map(entity, model);
                    context.SaveChanges();

                    return _mapper.Map<SourceModelFieldsEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModelFields - Update: {ex.Message}");
                return new SourceModelFieldsEntity();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModelFields.FirstOrDefault(x => x.Id == id);
                    if (model != null)
                    {
                        context.SourceModelFields.Remove(model);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModelFields - Delete: {ex.Message}");
            }
        }

        public SourceModelFieldsEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.SourceModelFields.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<SourceModelFieldsEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModelFields - GetById: {ex.Message}");
                return new SourceModelFieldsEntity();
            }
        }

        public IEnumerable<SourceModelFieldsEntity> GetAll()
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var list = context.SourceModelFields.ToList();
                    return _mapper.Map<IEnumerable<SourceModelFieldsEntity>>(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] SourceModelFields - GetAll: {ex.Message}");
                return new List<SourceModelFieldsEntity>();
            }
        }
    }
}
