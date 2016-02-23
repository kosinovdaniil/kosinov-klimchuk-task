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
using DAL.Interfacies.Repository;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class SubItemRepository : Repository<DalSubItem, SubItem>, ISubItemRepository
    {
        #region Constructor
        public SubItemRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<DalSubItem> GetSubItems(int id)
        {
            var ormitem = context.Set<ToDoItem>().FirstOrDefault(item => item.Id == id);
            return ormitem?.SubItems.Select(MapToDalEntity);
        }
        #endregion

        #region Override methods
        public override void Delete(DalSubItem e)
        {
            //TODO probably not necessary db access
            var item = e.ToOrmSubItem();
            item = context.Set<SubItem>().FirstOrDefault(x => x.Id == item.Id);

            if (item != null)
            {
                context.Set<SubItem>().Remove(item);
            }
        }
        #endregion

        #region Protected methods
        protected override DalSubItem MapToDalEntity(SubItem entity)
        {
            return entity.ToDalSubItem();
        }

        protected override SubItem MapToEntity(DalSubItem dalEntity)
        {
            return dalEntity.ToOrmSubItem();
        }

        protected override void CopyEntityFields(DalSubItem source, SubItem target)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}