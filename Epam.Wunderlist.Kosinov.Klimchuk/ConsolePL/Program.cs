using BLL.Interface.Services;
using DependencyResolver;
using Ninject;


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
