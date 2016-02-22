using BLL.Interface.Entities;
using BLL.Interface.Services;
using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface IToDoListService : ICrudService<BllToDoList>
    {
        IEnumerable<BllToDoItem> GetByList(int id);
    }
}
