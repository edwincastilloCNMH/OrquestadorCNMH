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

        public UsuarioEntity Create(UsuarioEntity entity)
		{
			return _usersRepository.Create(entity);
        }

        public UsuarioEntity Update(UsuarioEntity entity)
		{
			return _usersRepository.Update(entity);
        }

        public UsuarioEntity GetById(int id)
		{
			return _usersRepository.GetById(id);
        }

		public UsuarioEntity GetByNumDoc(string numDocument)
		{
			return _usersRepository.GetByNumDoc(numDocument);
        }

		public UsuarioEntity GetByemail(string email)
		{
			return _usersRepository.GetByemail(email);
        }

        public IEnumerable<UsuarioEntity> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public PagedResult<UsuarioEntity> GetAllUsersPaged(int page, int pageSize)
        {
            return _usersRepository.GetAllUsersPaged(page, pageSize);
        }

        public UsuarioEntity GetByResetToken(string token)
        {
            return _usersRepository.GetByResetToken(token);
        }
    }
}
