using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using BLL;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ToDoItemService : ICrudService<BllToDoItem>
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalToDoItem> itemRepository;

        public ToDoItemService(IUnitOfWork uow, IRepository<DalToDoItem> repository)
        {
            this.uow = uow;
            this.itemRepository = repository;
        }

        public IEnumerable<BllToDoItem> GetAllItems()
        {
            return itemRepository.GetAll().Select(x => x.ToBllItem());
        }

        public BllToDoItem Get(int id)
        {
            return itemRepository.GetById(id).ToBllItem();
        }

        public BllToDoItem Create(BllToDoItem entity)
        {
            var temp = itemRepository.Create(entity.ToDalItem());
            if (temp != null)
                uow.Commit();
            return temp?.ToBllItem();
        }

        public void Update(BllToDoItem entity)
        {
            itemRepository.Update(entity.ToDalItem());
            uow.Commit();
        }

        public void Delete(BllToDoItem entity)
        {
            itemRepository.Delete(entity.ToDalItem());
            uow.Commit();
        }
    }
}