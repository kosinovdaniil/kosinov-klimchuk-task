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
    public class SubItemRepository : IRepository<DalSubItem>
    {
        private readonly DbContext _context;

        public SubItemRepository(DbContext uow)
        {
            this._context = uow;
        }

        public DalSubItem Create(DalSubItem e)
        {
            var item = e.ToOrmSubItem();

            item = _context.Set<SubItem>().Add(item);
            return item.ToDalSubItem();
        }

        public void Delete(DalSubItem e)
        {
            //TODO probably not necessary db access
            var item = e.ToOrmSubItem();
            item = _context.Set<SubItem>().FirstOrDefault(x => x.Id == item.Id);

            if (item != null)
            {
                _context.Set<SubItem>().Remove(item);
            }
        }

        public IEnumerable<DalSubItem> GetAll()
        {
            return _context.Set<SubItem>().ToList().Select(x => x.ToDalSubItem());
        }

        public DalSubItem GetById(int key)
        {
            var ormItem = _context.Set<SubItem>().First(x => x.Id == key);
            return ormItem.ToDalSubItem();

        }

        public void Update(DalSubItem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalSubItem> GetByPredicate(Expression<Func<DalSubItem, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}