using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
	public class UsuarioService
	{
		private readonly IUsuarioRepository _usersRepository;

		public UsuarioService(IUsuarioRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

        public UsuarioEntiy Create(UsuarioEntiy entity)
		{
			return _usersRepository.Create(entity);
        }

        public UsuarioEntiy Update(UsuarioEntiy entity)
		{
			return _usersRepository.Update(entity);
        }

        public UsuarioEntiy GetById(int id)
		{
			return _usersRepository.GetById(id);
        }

		public UsuarioEntiy GetByNumDoc(string numDocument)
		{
			return _usersRepository.GetByNumDoc(numDocument);
        }

		public UsuarioEntiy GetByemail(string email)
		{
			return _usersRepository.GetByemail(email);
        }
    }
}
