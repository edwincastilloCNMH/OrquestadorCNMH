using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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

        public UsuarioEntiy Create(UsuarioEntiy entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = _mapper.Map<UsuarioModel>(entity);
                    context.UsuarioModel.Add(model);
                    context.SaveChanges();
                    return _mapper.Map<UsuarioEntiy>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - Create: {ex.Message}");
                return new UsuarioEntiy();
            }
        }

        public UsuarioEntiy Update(UsuarioEntiy entity)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var existing = context.UsuarioModel.FirstOrDefault(x => x.Id == entity.Id);
                    if (existing == null)
                        return new UsuarioEntiy();

                    _mapper.Map(entity, existing);
                    context.SaveChanges();

                    return _mapper.Map<UsuarioEntiy>(existing);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - Update: {ex.Message}");
                return new UsuarioEntiy();
            }
        }

        public UsuarioEntiy GetById(int id)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.Id == id);
                    return _mapper.Map<UsuarioEntiy>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetById: {ex.Message}");
                return new UsuarioEntiy();
            }
        }

        public UsuarioEntiy GetByNumDoc(string numDocument)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.NumDocumento == numDocument);
                    return _mapper.Map<UsuarioEntiy>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetByNumDoc: {ex.Message}");
                return new UsuarioEntiy();
            }
        }

        public UsuarioEntiy GetByemail(string email)
        {
            try
            {
                using (var context = new WebAPIContext())
                {
                    var model = context.UsuarioModel.FirstOrDefault(x => x.Correo == email);
                    return _mapper.Map<UsuarioEntiy>(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Repository Error] Usuario - GetByemail: {ex.Message}");
                return new UsuarioEntiy();
            }
        }
    }
}
