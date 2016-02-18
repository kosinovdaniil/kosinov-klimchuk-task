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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this._uow = uow;
            this._userRepository = repository;
        }

        public BllUser Get(int id)
        {
            return _userRepository.GetById(id).ToBllUser();
        }
        
        public IEnumerable<BllUser> GetAllUserEntities()
        {
            return _userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public BllUser Create(BllUser user)
        {
            var temp = _userRepository.Create(user.ToDalUser());
            if (temp != null)
                _uow.Commit();
            return temp?.ToBllUser();
        }


        public void Delete(BllUser user)
        {
            _userRepository.Delete(user.ToDalUser());
            _uow.Commit();
        }

        public IEnumerable<BllUser> GetUsersByPredicate(Expression<Func<BllUser, bool>> f)
        {

            return null;
        }

        public void Update(BllUser user)
        {
            _userRepository.Update(user.ToDalUser());
            _uow.Commit();
        }

        public BllUser ValidateUser(string email, string password)
        {
            var user = _userRepository.GetByMail(email);
            if (user?.Password == password)
                return user.ToBllUser();
            return null;
        }

        public BllUser Get(string name)
        {
            return _userRepository.GetByName(name).ToBllUser();
        }

    }
}
