using DAL.Interface.DTO;
using ORM;
using System.Linq;

namespace DAL.Mappers
{
    public static class DalListMapper
    {
        public static DalToDoList ToDalList(this ToDoList e)
        {
            return new DalToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                Name = e.Name,
                UsersId = e.Users?.Select(x => x.Id).ToList()
            };
        }

        public static ToDoList ToOrmList(this DalToDoList e)
        {
            return new ToDoList()
            {
                Id = e.Id,
                IsNotified = e.IsNotified,
                Name = e.Name,
            };
        }
    }
}
