using Epam.Wunderlist.DataAccess.MssqlProvider.Concrete;
using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        #region Constructor
        public ToDoItemRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<ToDoItem> GetByList(int id)
        {
            var items = context.Set<ToDoItem>().Where(item => item.List.Id == id);
            return items;
        }
        #endregion

        public override void Delete(ToDoItem item)
        {
            //TODO probably not necessary db access
            item = context.Set<ToDoItem>().FirstOrDefault(x => x.Id == item.Id);
            if (item != null)
            {
                context.Set<ToDoItem>().Remove(item);
            }
        }
    }
}