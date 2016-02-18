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
        private readonly IUnitOfWork _uow;
        private readonly IRepository<DalToDoItem> _itemRepository;

        public ToDoItemService(IUnitOfWork uow, IRepository<DalToDoItem> repository)
        {
            this._uow = uow;
            this._itemRepository = repository;
        }

        public IEnumerable<BllToDoItem> GetAllItems()
        {
            return _itemRepository.GetAll().Select(x => x.ToBllItem());
        }

        public BllToDoItem Get(int id)
        {
            return _itemRepository.GetById(id).ToBllItem();
        }

        public BllToDoItem Create(BllToDoItem entity)
        {
            var temp = _itemRepository.Create(entity.ToDalItem());
            if (temp != null)
                _uow.Commit();
            return temp?.ToBllItem();
        }

        public void Update(BllToDoItem entity)
        {
            _itemRepository.Update(entity.ToDalItem());
            _uow.Commit();
        }

        public void Delete(BllToDoItem entity)
        {
            _itemRepository.Delete(entity.ToDalItem());
            _uow.Commit();
        }
    }
}