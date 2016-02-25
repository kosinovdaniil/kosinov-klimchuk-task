using System;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}