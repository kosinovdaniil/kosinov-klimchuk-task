using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Collections.Generic;

namespace DAL.Interfacies.Repository
{
    public interface ISubItemRepository : IRepository<DalSubItem>
    {
        IEnumerable<DalSubItem> GetSubItems(int id);
    }
}
