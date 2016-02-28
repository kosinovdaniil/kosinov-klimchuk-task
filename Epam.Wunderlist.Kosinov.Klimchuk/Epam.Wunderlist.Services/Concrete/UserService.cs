using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;

namespace Epam.Wunderlist.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        #region Constructor
        public UserService(IUnitOfWork uow, IUserRepository repository)
            : base(uow, repository)
        { }
        #endregion

        #region Methods
        public User ValidateUser(string email, string password)
        {
            var user = ((IUserRepository)_repository).GetByMail(email);
            if (user?.Password == password)
                return user;
            return null;
        }

        public User Get(string mail)
        {
            return ((IUserRepository)_repository).GetByMail(mail);
        }
        #endregion
    }
}
