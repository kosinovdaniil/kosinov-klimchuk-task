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
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public UserEntity GetUserEntity(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }
        
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public UserEntity CreateUser(UserEntity user)
        {
            var temp = userRepository.Create(user.ToDalUser());
            if (temp != null)
                uow.Commit();
            return temp?.ToBllUser();
        }


        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }

        public IEnumerable<UserEntity> GetUsersByPredicate(Expression<Func<UserEntity, bool>> f)
        {

            return null;
        }

        public void UpdateUser(UserEntity user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        public UserEntity ValidateUser(string name, string password)
        {
            var user = userRepository.GetByName(name);
            if (user?.Password == password)
                return user.ToBllUser();
            return null;
        }

        public UserEntity GetUserEntity(string name)
        {
            return userRepository.GetByName(name).ToBllUser();
        }

    }
}
