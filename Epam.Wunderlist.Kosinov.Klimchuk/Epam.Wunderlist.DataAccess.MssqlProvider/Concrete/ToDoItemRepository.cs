using Epam.Wunderlist.DataAccess.MssqlProvider.Concrete;
using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        #region Constructor
        public ToDoItemRepository(DbContext context)
            : base(context)
        { }
        #endregion

        #region Methods
        public IEnumerable<ToDoItem> GetByList(int id)
        {
            var items = GetByPredicate(item => item.List.Id == id);
            return items;
        }

        public override ToDoItem Create(ToDoItem entity)
        {
            entity.List = _context.Set<ToDoList>()
                        .FirstOrDefault(x => x.Id == entity.List.Id);
            return base.Create(entity);
        }

        public override void Delete(ToDoItem item)
        {
            //TODO probably not necessary db access
            item = _context.Set<ToDoItem>().FirstOrDefault(x => x.Id == item.Id);
            if (item != null)
            {
                _context.Set<ToDoItem>().Remove(item);
            }
        }
        #endregion

        #region Protected methods
        protected override void CopyEntityFields(ToDoItem source, ToDoItem target)
        {
            target.Text = source.Text ?? target.Text;
            target.DateCompletion = source.DateCompletion ?? target.DateCompletion;
            target.Note = source.Note ?? target.Note;
            target.IsCompleted = source.IsCompleted;
            target.List = source.List ?? target.List;
        }
        #endregion
    }
}