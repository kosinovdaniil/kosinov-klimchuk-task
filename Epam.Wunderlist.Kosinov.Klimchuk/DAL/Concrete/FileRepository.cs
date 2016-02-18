using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System.Collections;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class FileRepository : IRepository<DalFile>
    {
        private readonly DbContext _context;

        public FileRepository(DbContext uow)
        {
            this._context = uow;
        }

        public DalFile Create(DalFile e)
        {
            var file = e.ToOrmFile();

            file = _context.Set<File>().Add(file);
            return file.ToDalFile();
        }

        public void Delete(DalFile e)
        {
            //TODO probably not necessary db access
            var file = e.ToOrmFile();
            file = _context.Set<File>().FirstOrDefault(x => x.Id == file.Id);

            if (file != null)
            {
                _context.Set<File>().Remove(file);
            }
        }

        public IEnumerable<DalFile> GetAll()
        {
            return _context.Set<File>().ToList().Select(x => x.ToDalFile());
        }

        public DalFile GetById(int key)
        {
            var ormFile = _context.Set<File>().First(x => x.Id == key);
            return ormFile.ToDalFile();

        }

        public void Update(DalFile entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalFile> GetByPredicate(Expression<Func<DalFile, bool>> f)
        {
            throw new NotImplementedException();
        }
    }
}