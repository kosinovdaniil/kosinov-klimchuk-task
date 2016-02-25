
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        #region Constructor
        public ToDoListRepository(DbContext context)
            : base(context)
        { }
        #endregion

        #region Methods
        public IEnumerable<ToDoList> GetByUser(int id)
        {
            var lists = context.Set<ToDoList>()
                .Where(list => list.Users.Select(user => user.Id).Contains(id));
            return lists;
        }

        public override void Delete(ToDoList list)
        {
            //TODO probably not necessary db access
            list = context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            foreach (var item in list.Items) // TODO DRY
            {
                //context.Set<ToDoItem>().Remove(item);
                //cascade
            }

            if (list != null)
            {
                context.Set<ToDoList>().Remove(list);
            }
        }
        #endregion
    }
}