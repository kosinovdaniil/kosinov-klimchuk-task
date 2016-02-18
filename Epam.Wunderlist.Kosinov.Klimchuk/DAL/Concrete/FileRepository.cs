using System;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using ORM;
using DAL.Interfacies.Repository;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class FileRepository : Repository<DalFile, File>, IFileRepository
    {
        #region Constructor
        public FileRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods

        #endregion

        #region Override methods
        public virtual void Delete(DalFile e)
        {
            //TODO probably not necessary db access
            var file = e.ToOrmFile();
            file = context.Set<File>().FirstOrDefault(x => x.Id == file.Id);

            if (file != null)
            {
                context.Set<File>().Remove(file);
            }
        }
        #endregion

        #region Protected Methods
        protected override DalFile MapToDalEntity(File entity)
        {
            return entity.ToDalFile();
        }

        protected override File MapToEntity(DalFile dalEntity)
        {
            return dalEntity.ToOrmFile();
        }

        protected override void CopyEntityFields(DalFile source, File target)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}