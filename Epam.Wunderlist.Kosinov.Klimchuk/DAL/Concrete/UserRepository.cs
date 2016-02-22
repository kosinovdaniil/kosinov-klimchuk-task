using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using DAL.Mappers;
using System.Collections.Generic;

namespace DAL.Concrete
{
    public class UserRepository : Repository<DalUser, User>, IUserRepository
    {
        #region Constructor
        public UserRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        public DalUser GetByName(string name)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Name == name);
            return ormuser?.ToDalUser();
        }

        public DalUser GetByMail(string mail)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Email == mail);
            return ormuser?.ToDalUser();
        }

        public IEnumerable<DalToDoList> GetByUser(int id)
        {
            var ormuser = context.Set<User>().FirstOrDefault(item => item.Id == id);
            return ormuser?.Lists.Select(item => item.ToDalList());
        }
        #endregion

        #region Override methods
        public override void Delete(DalUser e)
        {
            base.Delete(e);
            //TODO delete all plans for this user
        }
        #endregion

        #region Protected methods
        protected override DalUser MapToDalEntity(User entity)
        {
            return entity.ToDalUser();
        }

        protected override User MapToEntity(DalUser dalEntity)
        {
            return dalEntity.ToOrmUser();
        }

        protected override void CopyEntityFields(DalUser source, User target)
        {
            source.CopyFieldsTo(target);
        }
        #endregion
    }
}