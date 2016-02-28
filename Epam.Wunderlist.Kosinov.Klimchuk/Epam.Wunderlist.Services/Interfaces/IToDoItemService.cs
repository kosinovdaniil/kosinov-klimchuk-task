using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IToDoItemService : ICrudService<ToDoItem>
    {
        IEnumerable<ToDoItem> GetByList(int id);
    }
}
