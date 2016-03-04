using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            var lists = GetByPredicate(list => list.Users.Select(x => x.Id).Contains(id));
            return lists;
        }

        public override void Delete(ToDoList list)
        {
            //TODO probably not necessary db access
            list = context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            if (list != null)
            {
                context.Set<ToDoList>().Remove(list);
            }
            foreach (var item in list.ItemsId)
            {
                //context.Set<ToDoItem>().Remove(item);
                //cascade
            }
        }
        #endregion

        #region Protected methods
        protected override void CopyEntityFields(ToDoList source, ToDoList target)
        {
            target.Name = source.Name ?? target.Name;
        }
        #endregion
    }
}