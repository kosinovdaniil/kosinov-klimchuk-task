using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System.Collections;
using System.Threading.Tasks;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class ToDoItemRepository : IRepository<DalToDoItem>
    {
        private readonly DbContext _context;

        public ToDoItemRepository(DbContext uow)
        {
            this._context = uow;
        }

        public DalToDoItem Create(DalToDoItem e)
        {
            var item = e.ToOrmItem();

            item = _context.Set<ToDoItem>().Add(item);
            return item.ToDalItem();
        }

        public void Delete(DalToDoItem e)
        {
            //TODO probably not necessary db access
            var item = e.ToOrmItem();
            item = _context.Set<ToDoItem>().FirstOrDefault(x => x.Id == item.Id);
            if (item != null)
            {
                _context.Set<ToDoItem>().Remove(item);
            }
        }

        public IEnumerable<DalToDoItem> GetAll()
        {
            return _context.Set<ToDoItem>().ToList().Select(x => x.ToDalItem());
        }

        public DalToDoItem GetById(int key)
        {
            var ormItem = _context.Set<ToDoItem>().First(x => x.Id == key);
            return ormItem.ToDalItem();

        }


        public IEnumerable<DalToDoItem> GetByPredicate(Expression<Func<DalToDoItem, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalToDoItem entity)
        {
            //TODO this won't work!
            var original = _context.Set<DalToDoItem>().FirstOrDefault(x => x.Id == entity.Id);
            if (original != null)
            {
                var updatedItem = entity.ToOrmItem();

                if (updatedItem.Text != null)
                    original.Text = updatedItem.Text;
                if (updatedItem.Note != null)
                    original.Note = updatedItem.Note;
                if (updatedItem.Note != null)
                    original.Note = updatedItem.Note;
                //if (updatedItem.CompletionDate != null)
                //    original.CompletionDate = updatedItem.CompletionDate;
            }
        }
    }
}