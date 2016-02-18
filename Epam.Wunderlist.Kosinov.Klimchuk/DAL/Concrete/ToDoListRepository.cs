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
    public class ToDoListRepository : IRepository<DalToDoList>
    {
        private readonly DbContext _context;

        public ToDoListRepository(DbContext uow)
        {
            this._context = uow;
        }

        public DalToDoList Create(DalToDoList e)
        {
            var item = e.ToOrmList();

            item = _context.Set<ToDoList>().Add(item);
            return item.ToDalList();
        }

        public void Delete(DalToDoList e)
        {
            //TODO probably not necessary db access
            var list = e.ToOrmList();
            list = _context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            foreach (var item in list.Items) // TODO DRY
            {
                foreach (var file in item.Files) // TODO maybe cascade delete will do, dont know
                {
                    _context.Set<File>().Remove(file);
                }
                foreach (var subitems in item.SubItems)// try cascade delete
                {
                    _context.Set<SubItem>().Remove(subitems);
                }
                _context.Set<ToDoItem>().Remove(item);
            }

            if (list != null)
            {
                _context.Set<ToDoList>().Remove(list);
            }
        }

        public IEnumerable<DalToDoList> GetAll()
        {
            return _context.Set<ToDoList>().ToList().Select(x => x.ToDalList());
        }

        public DalToDoList GetById(int key)
        {
            var ormList = _context.Set<ToDoList>().First(x => x.Id == key);
            return ormList.ToDalList();

        }

        public IEnumerable<DalToDoItem> GetByPredicate(Expression<Func<DalToDoItem, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalToDoList entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalToDoList> GetByPredicate(Expression<Func<DalToDoList, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}