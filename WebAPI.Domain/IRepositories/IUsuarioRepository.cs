using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
	public interface IUsuarioRepository : IDisposable
	{
        UsuarioEntity Create(UsuarioEntity entity);
        UsuarioEntity Update(UsuarioEntity entity);
        UsuarioEntity GetById(int id);
        UsuarioEntity GetByNumDoc(string numDocument);
        UsuarioEntity GetByemail(string email);
        IEnumerable<UsuarioEntity> GetAllUsers();
        PagedResult<UsuarioEntity> GetAllUsersPaged(int page, int pageSize);

        UsuarioEntity GetByResetToken(string token);
    }
}
