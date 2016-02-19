using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static BllUser ToBllUser(this DalUser e)
        {
            return new BllUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.ListsId,
                PhotoPath = e.PhotoPath
            };
        }

        public static DalUser ToDalUser(this BllUser e)
        {
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.ListsId,
                PhotoPath = e.PhotoPath
            };
        }
    }
}
