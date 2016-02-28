using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoListService : Service<ToDoList>, IToDoListService
    {
        #region Constructor
        public ToDoListService(IUnitOfWork uow, IToDoListRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Methods
        public IEnumerable<ToDoList> GetByUser(int id)
        {
            return ((IToDoListRepository)_repository).GetByUser(id);
        }
        #endregion
    }
}