using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        IEnumerable<ToDoList> GetByUser(int id);
    }
}
