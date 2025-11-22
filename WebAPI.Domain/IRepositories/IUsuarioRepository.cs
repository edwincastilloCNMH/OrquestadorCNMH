using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
	public interface IUsuarioRepository : IDisposable
	{
        UsuarioEntiy Create(UsuarioEntiy entity);
        UsuarioEntiy Update(UsuarioEntiy entity);
        UsuarioEntiy GetById(int id);
        UsuarioEntiy GetByNumDoc(string numDocument);
        UsuarioEntiy GetByemail(string email);
    }
}
