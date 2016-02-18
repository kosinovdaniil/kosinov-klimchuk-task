using BLL.Interface.Entities;
using MvcPL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static BllUser ToBllUser(this UserViewModel e)
        {
            return new BllUser()
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                PhotoPath = e.Email
            };
        }
        public static UserViewModel ToUserViewModel(this BllUser e)
        {
            return new UserViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Email=e.Email,
            };
        }
    }
}