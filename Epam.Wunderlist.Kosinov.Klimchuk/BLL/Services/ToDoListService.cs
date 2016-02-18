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
    public class ToDoListSerivce : ICrudService<BllToDoList>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<DalToDoList> _listRepository;

        public ToDoListSerivce(IUnitOfWork uow, IRepository<DalToDoList> repository)
        {
            this._uow = uow;
            this._listRepository = repository;
        }

        public IEnumerable<BllToDoList> GetAllItems()
        {
            return _listRepository.GetAll().Select(x => x.ToBllList());
        }

        public BllToDoList Get(int id)
        {
            return _listRepository.GetById(id).ToBllList();
        }

        public BllToDoList Create(BllToDoList entity)
        {
            var temp = _listRepository.Create(entity.ToDalList());
            if (temp != null)
                _uow.Commit();
            return temp?.ToBllList();
        }

        public void Update(BllToDoList entity)
        {
            _listRepository.Update(entity.ToDalList());
            _uow.Commit();
        }

        public void Delete(BllToDoList entity)
        {
            _listRepository.Delete(entity.ToDalList());
            _uow.Commit();
        }
    }
}