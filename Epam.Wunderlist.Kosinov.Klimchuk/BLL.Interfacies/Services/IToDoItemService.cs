using BLL.Interface.Entities;
using BLL.Interface.Services;
using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface IToDoItemService : ICrudService<BllToDoItem>
    {
        IEnumerable<BllFile> GetByItem(int id);

        IEnumerable<BllSubItem> GetSubItems(int id);
     }
}
