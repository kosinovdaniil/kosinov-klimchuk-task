﻿using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using DAL.Interfacies.Repository;
using BLL.Interfacies.Services;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<ApplicationDbContext>().InSingletonScope();
            }
            

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IToDoItemRepository>().To<ToDoItemRepository>();
            kernel.Bind<IToDoListRepository>().To<ToDoListRepository>();
            
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ISignInService>().To<SignInService>();
            kernel.Bind<IToDoItemService>().To<ToDoItemService>();
            kernel.Bind<IToDoListService>().To<ToDoListService>();           
        }
    }
}