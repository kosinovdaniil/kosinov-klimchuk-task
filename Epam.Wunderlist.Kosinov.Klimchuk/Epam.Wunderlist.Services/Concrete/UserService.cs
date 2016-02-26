using Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public BllUser ValidateUser(string email, string password)
        {
            var user = ((IUserRepository)_repository).GetByMail(email);
            if (user?.Password == password)
                return user.ToBllUser();
            return null;
        }

        public BllUser Get(string mail)
        {
            return ((IUserRepository)_repository).GetByMail(mail).ToBllUser();
        }
        #endregion

        #region Protected methods
        protected override DalUser MapToDalEntity(BllUser entity)
        {
            return entity.ToDalUser();
        }

        protected override BllUser MapToBllEntity(DalUser entity)
        {
            return entity.ToBllUser();
        }
        #endregion
    }
}
