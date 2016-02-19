using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Interfacies.Services;

namespace BLL.Services
{
    public class SubItemService : Service<BllSubItem, DalSubItem>, ISubItemService
    {
        #region Constructor
        public SubItemService(IUnitOfWork uow, IRepository<DalSubItem> repository)
            : base(uow, repository) { }
        #endregion

        #region Protected methods
        protected override DalSubItem MapToDalEntity(BllSubItem entity)
        {
            return entity.ToDalSubItem();
        }

        protected override BllSubItem MapToBllEntity(DalSubItem entity)
        {
            return entity.ToBllSubItem();
        }
        #endregion
    }
}