using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByName(string name);

        DalUser GetByMail(string mail);

        IEnumerable<DalToDoList> GetByUser(int id);
    }
}