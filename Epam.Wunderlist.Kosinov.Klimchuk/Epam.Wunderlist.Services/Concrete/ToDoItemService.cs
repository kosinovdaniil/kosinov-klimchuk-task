using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Concrete
{
    public class ToDoItemService : Service<ToDoItem>, IToDoItemService
    {
        #region Constructor
        public ToDoItemService(IUnitOfWork uow, IToDoItemRepository repository)
            : base(uow, repository)
        { }
        #endregion
        #region Methods
        public IEnumerable<ToDoItem> GetByList(int id)
        {
            return ((IToDoItemRepository)_repository).GetByList(id);
        }
        #endregion
    }
}
