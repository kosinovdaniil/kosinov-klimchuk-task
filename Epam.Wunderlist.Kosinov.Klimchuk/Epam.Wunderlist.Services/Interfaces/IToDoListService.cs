using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IToDoListService : ICrudService<ToDoList>
    {
        IEnumerable<ToDoList> GetByUser(int id);
    }
}
