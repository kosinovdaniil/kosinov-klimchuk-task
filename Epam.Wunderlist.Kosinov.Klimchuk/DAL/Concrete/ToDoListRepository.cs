﻿using System;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using ORM;
using DAL.Mappers;
using DAL.Interfacies.Repository;
using System.Collections.Generic;

namespace DAL.Concrete
{
    public class ToDoListRepository : Repository<DalToDoList, ToDoList>, IToDoListRepository
    {
        #region Constructor
        public ToDoListRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<DalToDoList> GetByUser(int id)
        {
            var ormuser = context.Set<User>().FirstOrDefault(item => item.Id == id);
            return ormuser?.Lists.Select(MapToDalEntity);
        }

        public override void Delete(DalToDoList e)
        {
            //TODO probably not necessary db access
            var list = e.ToOrmList();
            list = context.Set<ToDoList>().FirstOrDefault(x => x.Id == list.Id);
            foreach (var item in list.Items) // TODO DRY
            {
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