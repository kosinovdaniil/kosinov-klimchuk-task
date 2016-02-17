﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System.Collections;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        private bool UserExists(string username)
        {
            return context.Set<User>().Any(x => x.Name == username);
        }
        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().ToList().Select(user => user.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().First(user => user.Id == key);
            return ormuser.ToDalUser();
        }

        public DalUser GetByName(string name)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Name == name);
            return ormuser?.ToDalUser();
        }

        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public DalUser Create(DalUser e)
        {
            if (UserExists(e.Name))
                return null;
            var user = e.ToOrmUser();
           
            user = context.Set<User>().Add(user);
            return user.ToDalUser();
        }

        public void Delete(DalUser e)
        {
            var user = e.ToOrmUser();
            user = context.Set<User>().FirstOrDefault(u => u.Id == user.Id);
            if (user != null)
            {
                //TODO delete all plans for this user
                context.Set<User>().Remove(user);
            }

        }

        public void Update(DalUser entity)
        {
            var original = context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);
            if (original != null)
            {
                var updatedUser = entity.ToOrmUser();

                if (updatedUser.Name != null)
                    original.Name = updatedUser.Name;
                if (updatedUser.Password != null)
                    original.Password = updatedUser.Password;
            }
        }

        public DalUser GetByMail(string mail)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Email == mail);
            return ormuser?.ToDalUser();
        }
    }
}