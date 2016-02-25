using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByMail(string mail);
    }
}