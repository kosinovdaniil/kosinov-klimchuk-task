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
using DAL.Interfacies.Repository;

namespace DAL.Concrete
{
    public class ToDoItemRepository : Repository<DalToDoItem, ToDoItem>, IToDoItemRepository
    {
        #region Constructor
        public ToDoItemRepository(DbContext context)
            : base(context) { }
        #endregion
      
        public override void Delete(DalToDoItem e)
        {
            //TODO probably not necessary db access
            var item = e.ToOrmItem();
            item = context.Set<ToDoItem>().FirstOrDefault(x => x.Id == item.Id);
            if (item != null)
            {
                context.Set<ToDoItem>().Remove(item);
            }
        }

        #region Protected methods
        protected override void CopyEntityFields(DalToDoItem source, ToDoItem target)
        {
            throw new NotImplementedException();
        }

        protected override DalToDoItem MapToDalEntity(ToDoItem entity)
        {
            return entity.ToDalItem();
        }

        protected override ToDoItem MapToEntity(DalToDoItem dalEntity)
        {
            return dalEntity.ToOrmItem();
        }
        #endregion
    }
}