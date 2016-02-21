using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class FileService : Service<BllFile, DalFile>, IFileService
    {
        #region Constructor
        public FileService(IUnitOfWork uow, IFileRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Protected methods
        protected override DalFile MapToDalEntity(BllFile entity)
        {
            return entity.ToDalFile();
        }

        protected override BllFile MapToBllEntity(DalFile entity)
        {
            return entity.ToBllFile();
        }
        #endregion
    }
}