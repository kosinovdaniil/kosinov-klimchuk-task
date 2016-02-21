using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class ToDoListService : Service<BllToDoList, DalToDoList>, IToDoListService
    {
        #region Constructor
        public ToDoListService(IUnitOfWork uow, IToDoListRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Protected methods
        protected override DalToDoList MapToDalEntity(BllToDoList entity)
        {
            return entity.ToDalList();
        }

        protected override BllToDoList MapToBllEntity(DalToDoList entity)
        {
            return entity.ToBllList();
        }
        #endregion
    }
}