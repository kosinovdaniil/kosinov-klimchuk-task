using BLL.Interface.Services;
using DependencyResolver;
using Ninject;

using BLL.Interface.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsolePL
{
    static class Program
    {
        static void Main(string[] args)
        {

            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
            var service = resolver.Get<IUserService>();

        }
    }
}
