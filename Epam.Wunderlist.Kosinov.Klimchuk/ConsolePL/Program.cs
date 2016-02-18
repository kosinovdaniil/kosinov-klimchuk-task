using BLL.Interface.Services;
using DependencyResolver;
using Ninject;
using System;
using System.Linq;

namespace ConsolePL
{
    static class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            //var service = resolver.Get<IUserService>();
            Console.WriteLine("HELLO!");
            //var list = service.GetAllUserEntities().ToList();

            //foreach (var user in list)
            //{
            //    Console.WriteLine(user.Name);
            //}
            Console.ReadLine();
        }
    }
}
