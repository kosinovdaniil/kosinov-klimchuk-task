using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByName(string name);

        DalUser GetByMail(string mail);
    }
}