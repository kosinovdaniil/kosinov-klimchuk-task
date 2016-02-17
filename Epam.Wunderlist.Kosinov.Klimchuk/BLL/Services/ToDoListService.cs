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
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalToDoList> listRepository;

        public ToDoListSerivce(IUnitOfWork uow, IRepository<DalToDoList> repository)
        {
            this.uow = uow;
            this.listRepository = repository;
        }

        public IEnumerable<BllToDoList> GetAllItems()
        {
            return listRepository.GetAll().Select(x => x.ToBllList());
        }

        public BllToDoList Get(int id)
        {
            return listRepository.GetById(id).ToBllList();
        }

        public BllToDoList Create(BllToDoList entity)
        {
            var temp = listRepository.Create(entity.ToDalList());
            if (temp != null)
                uow.Commit();
            return temp?.ToBllList();
        }

        public void Update(BllToDoList entity)
        {
            listRepository.Update(entity.ToDalList());
            uow.Commit();
        }

        public void Delete(BllToDoList entity)
        {
            listRepository.Delete(entity.ToDalList());
            uow.Commit();
        }
    }
}