using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Collections.Generic;

namespace DAL.Interfacies.Repository
{
    public interface IFileRepository : IRepository<DalFile>
    {
        IEnumerable<DalFile> GetByItem(int id);
    }
}
