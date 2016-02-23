using BLL.Interface.Entities;
using BLL.Interface.Services;
using System.Collections.Generic;

namespace BLL.Interfacies.Services
{
    public interface IFileService : ICrudService<BllFile>
    {
        IEnumerable<BllFile> GetByItem(int id);
    }
}
