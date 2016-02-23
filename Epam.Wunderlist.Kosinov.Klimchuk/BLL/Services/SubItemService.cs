using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SubItemService : Service<BllSubItem, DalSubItem>, ISubItemService
    {
        #region Constructor
        public SubItemService(IUnitOfWork uow, ISubItemRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Methods
        public IEnumerable<BllSubItem> GetSubItems(int id)
        {
            return ((ISubItemRepository)_repository).GetSubItems(id).Select(item => item.ToBllSubItem());
        }
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