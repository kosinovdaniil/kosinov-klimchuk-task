using BLL.Interface.Entities;
using BLL.Interface.Services;
using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface IToDoItemService : ICrudService<BllToDoItem>
    {
        IEnumerable<BllToDoItem> GetByList(int id);
    }
}
