using System;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}