using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Profiles;

namespace WebAPI.Infrastructure.Repositories
{
    public class UsuarioRepository: IUsuarioRepository, IDisposable
    {
        private readonly IMapper _mapper;

        public UsuarioRepository()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastructureProfile>();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(mapConfig);
        }

        public void Dispose() { }

        public UsuarioEntity Create(UsuarioEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<UsuarioModel>(entity);
                    context.UsuarioModel.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<UsuarioEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - Create: {ex.Message}");
                return new UsuarioEntity();
            }
        }

        public UsuarioEntity Update(UsuarioEntity entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.UsuarioModel.FirstOrDefault(x => x.Id == entity.Id);
                    if (existing == null)
                        return new UsuarioEntity();

                    _mapper.Map(entity, existing);
                    context.SaveChanges();

                    return _mapper.Map<UsuarioEntity>(existing);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - Update: {ex.Message}");
                return new UsuarioEntity();
            }
        }

        public UsuarioEntity GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<UsuarioEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetById: {ex.Message}");
                return new UsuarioEntity();
            }
        }

        public UsuarioEntity GetByNumDoc(string numDocument)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.NumDocumento == numDocument);
                    return _mapper.Map<UsuarioEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetByNumDoc: {ex.Message}");
                return new UsuarioEntity();
            }
        }

        public UsuarioEntity GetByemail(string email)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.Correo == email);
                    return _mapper.Map<UsuarioEntity>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetByemail: {ex.Message}");
                return new UsuarioEntity();
            }
        }

        public IEnumerable<UsuarioEntity> GetAllUsers()
        {

            try
            {
                using (var context = new WebAPIContext())
                {
                    var users = context.UsuarioModel.ToList();
                    return _mapper.Map<IEnumerable<UsuarioEntity>>(users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetAllUsers: {ex.Message}");
                return new List<UsuarioEntity>();
            }
        }

        public PagedResult<UsuarioEntity> GetAllUsersPaged(int page, int pageSize)
        {

            try
            {
                using (var context = new WebAPIContext())
                {
                    var query = context.UsuarioModel.AsQueryable();

                    var total = query.Count();

                    var data = query
                        .OrderBy(x => x.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    return new PagedResult<UsuarioEntity>
                    {
                        Total = total,
                        Items = _mapper.Map<IEnumerable<UsuarioEntity>>(data)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetAllUsersPaged: {ex.Message}");
                return new PagedResult<UsuarioEntity>
                {
                    Total = 0,
                    Items = Enumerable.Empty<UsuarioEntity>()
                };
            }
            
        }
    }
}
