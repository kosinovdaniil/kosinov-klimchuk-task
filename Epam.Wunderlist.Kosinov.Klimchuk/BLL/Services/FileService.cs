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
        private readonly IUnitOfWork _uow;
        private readonly IRepository<DalFile> _fileRepository;

        public FileService(IUnitOfWork uow, IRepository<DalFile> repository)
        {
            this._uow = uow;
            this._fileRepository = repository;
        }

        public IEnumerable<BllFile> GetAllItems()
        {
            return _fileRepository.GetAll().Select(x => x.ToBllFile());
        }

        public BllFile Get(int id)
        {
            return _fileRepository.GetById(id).ToBllFile();
        }

        public BllFile Create(BllFile entity)
        {
            var temp = _fileRepository.Create(entity.ToDalFile());
            if (temp != null)
                _uow.Commit();
            return temp?.ToBllFile();
        }

        public void Update(BllFile entity)
        {
            _fileRepository.Update(entity.ToDalFile());
            _uow.Commit();
        }

        public void Delete(BllFile entity)
        {
            _fileRepository.Delete(entity.ToDalFile());
            _uow.Commit();
        }
    }
}