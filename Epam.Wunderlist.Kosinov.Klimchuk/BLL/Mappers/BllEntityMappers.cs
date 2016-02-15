using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Linq;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static UserEntity ToBllUser(this DalUser e)
        {
            return new UserEntity()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
 
            };
        }
        public static DalUser ToDalUser(this UserEntity e)
        {
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
            };
        }
      
    }
}
