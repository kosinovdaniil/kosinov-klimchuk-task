using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Linq;

namespace BLL.Mappers
{
    public static class BllListMapper
    {
        public static DalToDoList ToDalList(this BllToDoList e)
        {
            return new DalToDoList()
            {
                Id = e.Id,
                ItemsId = e.ItemsId,
                Name = e.Name,
                UsersId = e.UsersId?.ToList()
            };
        }

        public static BllToDoList ToBllList(this DalToDoList e)
        {
            return new BllToDoList()
            {
                Id = e.Id,
                ItemsId = e.ItemsId,
                Name = e.Name,
                UsersId = e.UsersId?.ToList()
            };
        }
    }
}
