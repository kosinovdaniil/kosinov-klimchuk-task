using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoListService : Service<ToDoList>, IToDoListService
    {
        #region Constructor
        public ToDoListService(IDbSession dbSession, IToDoListRepository repository)
            : base(dbSession, repository) { }
        #endregion

        #region Methods
        public IEnumerable<ToDoList> GetByUser(int id)
        {
            return ((IToDoListRepository)_repository).GetByUser(id);
        }
        #endregion
    }
}