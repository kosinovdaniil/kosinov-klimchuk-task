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

namespace DAL.Concrete
{
    public class ToDoItemRepository : IRepository<DalToDoItem>
    {
        private readonly DbContext context;

        public ToDoItemRepository(DbContext uow)
        {
            this.context = uow;
        }

        public DalToDoItem Create(DalToDoItem e)
        {
            var item = e.ToOrmItem();

            item = context.Set<ToDoItem>().Add(item);
            return item.ToDalItem();
        }

        public void Delete(DalToDoItem e)
        {
            //TODO probably not necessary db access
            var item = e.ToOrmItem();
            item = context.Set<ToDoItem>().FirstOrDefault(x => x.Id == item.Id);
            if (item != null)
            {
                context.Set<ToDoItem>().Remove(item);
            }
        }

        public void Delete(DalToDoList e)
        {
            //TODO probably not necessary db access
            var list = e.ToOrmList();
            list = context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            if (list != null)
            {
                context.Set<ToDoList>().Remove(list);
            }
        }

        public IEnumerable<DalToDoItem> GetAll()
        {
            return context.Set<ToDoItem>().ToList().Select(x => x.ToDalItem());
        }

        public DalToDoItem GetById(int key)
        {
            var ormItem = context.Set<ToDoItem>().First(x => x.Id == key);
            return ormItem.ToDalItem();

        }

        public DalToDoList GetListById(int key)
        {
            var ormList = context.Set<ToDoList>().First(x => x.Id == key);
            return ormList.ToDalList();

        }

        public DalToDoList GetListByName(string name)
        {
            var ormItem = context.Set<ToDoList>().FirstOrDefault(x => x.Name == name);
            return ormItem?.ToDalList();

        }

        public IEnumerable<DalToDoItem> GetByPredicate(Expression<Func<DalToDoItem, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalToDoItem entity)
        {
            //TODO this won't work!
            var original = context.Set<DalToDoItem>().FirstOrDefault(x => x.Id == entity.Id);
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

        public void Delete(DalSubItem item)
        {
            //TODO probably not necessary db access
            var orm = item.ToOrmSubItem();
            orm = context.Set<SubItem>().FirstOrDefault(x => x.Id == orm.Id);
            if (orm != null)
            {
                context.Set<SubItem>().Remove(orm);
            }
        }

        public void Delete(DalFile file)
        {
            //TODO probably not necessary db access
            var orm = file.ToOrmFile();
            orm = context.Set<File>().FirstOrDefault(x => x.Id == orm.Id);
            if (orm != null)
            {
                context.Set<File>().Remove(orm);
            }
        }
    }
}