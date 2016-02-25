using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using BLL;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : Service<BllUser, DalUser>, IUserService
    {
        #region Constructor
        public UserService(IUnitOfWork uow, IUserRepository repository)
            : base(uow, repository) { }
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
