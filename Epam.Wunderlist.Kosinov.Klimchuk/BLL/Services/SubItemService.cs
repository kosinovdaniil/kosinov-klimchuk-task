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
        private readonly IUnitOfWork _uow;
        private readonly IRepository<DalSubItem> _itemRepository;

        public SubItemService(IUnitOfWork uow, IRepository<DalSubItem> repository)
        {
            this._uow = uow;
            this._itemRepository = repository;
        }

        public IEnumerable<BllSubItem> GetAllItems()
        {
            return _itemRepository.GetAll().Select(x => x.ToBllSubItem());
        }

        public BllSubItem Get(int id)
        {
            return _itemRepository.GetById(id).ToBllSubItem();
        }

        public BllSubItem Create(BllSubItem entity)
        {
            var temp = _itemRepository.Create(entity.ToDalSubItem());
            if (temp != null)
                _uow.Commit();
            return temp?.ToBllSubItem();
        }

        public void Update(BllSubItem entity)
        {
            _itemRepository.Update(entity.ToDalSubItem());
            _uow.Commit();
        }

        public void Delete(BllSubItem entity)
        {
            _itemRepository.Delete(entity.ToDalSubItem());
            _uow.Commit();
        }
    }
}