using BLL.Interface.Entities;
using BLL.Interface.Services;
using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface ISubItemService : ICrudService<BllSubItem>
    {
        IEnumerable<BllSubItem> GetSubItems(int id);
    }
}
