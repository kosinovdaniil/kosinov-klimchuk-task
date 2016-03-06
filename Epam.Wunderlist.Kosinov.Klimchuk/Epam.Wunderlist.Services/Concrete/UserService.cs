using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using System;

namespace Epam.Wunderlist.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        #region Constructor
        public UserService(IDbSession dbSession, IUserRepository repository)
            : base(dbSession, repository)
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
            if (mail == null)
            {
                throw new ArgumentNullException("mail");
            }
            return ((IUserRepository)_repository).GetByMail(mail);
        }
        #endregion
    }
}
