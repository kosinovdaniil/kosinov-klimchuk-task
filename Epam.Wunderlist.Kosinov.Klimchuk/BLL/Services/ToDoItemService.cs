using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using BLL;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using System.Threading.Tasks;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class ToDoItemService : Service<BllToDoItem, DalToDoItem>, IToDoItemService
    {
        #region Constructor
        public ToDoItemService(IUnitOfWork uow, IToDoItemRepository repository)
            : base(uow, repository) { }
        #endregion
        #region Methods
        public IEnumerable<BllFile> GetByItem(int id)
        {
            return ((IToDoItemRepository)_repository).GetByItem(id).Select(item => item.ToBllFile());
        }

        public IEnumerable<BllSubItem> GetSubItems(int id)
        {
            return ((IToDoItemRepository)_repository).GetSubItems(id).Select(item => item.ToBllSubItem());
        }
        #endregion

        #region Protected methods
        protected override DalToDoItem MapToDalEntity(BllToDoItem entity)
        {
            return entity.ToDalItem();
        }

        protected override BllToDoItem MapToBllEntity(DalToDoItem entity)
        {
            return entity.ToBllItem();
        }
        #endregion
    }
}