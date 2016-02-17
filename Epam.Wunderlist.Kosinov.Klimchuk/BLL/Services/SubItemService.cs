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
    public class SubItemService : ICrudService<BllSubItem>
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalSubItem> itemRepository;

        public SubItemService(IUnitOfWork uow, IRepository<DalSubItem> repository)
        {
            this.uow = uow;
            this.itemRepository = repository;
        }

        public IEnumerable<BllSubItem> GetAllItems()
        {
            return itemRepository.GetAll().Select(x => x.ToBllSubItem());
        }

        public BllSubItem Get(int id)
        {
            return itemRepository.GetById(id).ToBllSubItem();
        }

        public BllSubItem Create(BllSubItem entity)
        {
            var temp = itemRepository.Create(entity.ToDalSubItem());
            if (temp != null)
                uow.Commit();
            return temp?.ToBllSubItem();
        }

        public void Update(BllSubItem entity)
        {
            itemRepository.Update(entity.ToDalSubItem());
            uow.Commit();
        }

        public void Delete(BllSubItem entity)
        {
            itemRepository.Delete(entity.ToDalSubItem());
            uow.Commit();
        }
    }
}