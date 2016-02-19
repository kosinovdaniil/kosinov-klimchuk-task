using System.Collections.Generic;
using BLL.Interface.Entities;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserService : ICrudService<BllUser>
    {
        BllUser Get(string nameOrMail);

        BllUser ValidateUser(string email, string password);
    }
}