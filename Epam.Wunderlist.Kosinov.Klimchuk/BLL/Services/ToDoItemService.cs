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

namespace BLL.Services
{
    public class ToDoItemService : Service<BllToDoItem, DalToDoItem>, IToDoItemService
    {
        #region Constructor
        public ToDoItemService(IUnitOfWork uow, IRepository<DalToDoItem> repository)
            : base(uow, repository) { }
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