using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.MssqlProvider.Concrete;
using Epam.Wunderlist.DataAccess.MssqlProvider;
using Epam.Wunderlist.Services.Concrete;
using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.Common
{
    public static class ResolverConfig
    {

        private static void Configure(IKernel kernel)
        {

            kernel.Bind<IDbSession>().To<DbSession>().InRequestScope();
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IToDoItemRepository>().To<ToDoItemRepository>();
            kernel.Bind<IToDoListRepository>().To<ToDoListRepository>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ISignInService>().To<SignInService>();
            kernel.Bind<IToDoItemService>().To<ToDoItemService>();
            kernel.Bind<IToDoListService>().To<ToDoListService>();

            kernel.Bind<ICrudService<ToDoItem>>().To<ToDoItemService>();
            kernel.Bind<ICrudService<ToDoList>>().To<ToDoListService>();
            kernel.Bind<ICrudService<User>>().To<UserService>();
        }
    }
}