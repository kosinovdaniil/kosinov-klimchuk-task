using System;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using ORM;
using DAL.Mappers;
using DAL.Interfacies.Repository;

namespace DAL.Concrete
{
    public class ToDoListRepository : Repository<DalToDoList, ToDoList>, IToDoListRepository
    {
        #region Constructor
        public ToDoListRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Override methods
        public override void Delete(DalToDoList e)
        {
            //TODO probably not necessary db access
            var list = e.ToOrmList();
            list = context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            foreach (var item in list.Items) // TODO DRY
            {
                foreach (var file in item.Files) // TODO maybe cascade delete will do, dont know
                {
                    context.Set<File>().Remove(file);
                }
                foreach (var subitems in item.SubItems)// try cascade delete
                {
                    context.Set<SubItem>().Remove(subitems);
                }
                context.Set<ToDoItem>().Remove(item);
            }

            if (list != null)
            {
                context.Set<ToDoList>().Remove(list);
            }
        }
        #endregion

        #region Protected methods
        protected override DalToDoList MapToDalEntity(ToDoList entity)
        {
            return entity.ToDalList();
        }

        protected override ToDoList MapToEntity(DalToDoList dalEntity)
        {
            return dalEntity.ToOrmList();
        }

        protected override void CopyEntityFields(DalToDoList source, ToDoList target)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}