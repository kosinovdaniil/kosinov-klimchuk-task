using Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
