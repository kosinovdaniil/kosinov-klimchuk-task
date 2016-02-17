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
    public class FileService : ICrudService<BllFile>
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalFile> fileRepository;

        public FileService(IUnitOfWork uow, IRepository<DalFile> repository)
        {
            this.uow = uow;
            this.fileRepository = repository;
        }

        public IEnumerable<BllFile> GetAllItems()
        {
            return fileRepository.GetAll().Select(x => x.ToBllFile());
        }

        public BllFile Get(int id)
        {
            return fileRepository.GetById(id).ToBllFile();
        }

        public BllFile Create(BllFile entity)
        {
            var temp = fileRepository.Create(entity.ToDalFile());
            if (temp != null)
                uow.Commit();
            return temp?.ToBllFile();
        }

        public void Update(BllFile entity)
        {
            fileRepository.Update(entity.ToDalFile());
            uow.Commit();
        }

        public void Delete(BllFile entity)
        {
            fileRepository.Delete(entity.ToDalFile());
            uow.Commit();
        }
    }
}