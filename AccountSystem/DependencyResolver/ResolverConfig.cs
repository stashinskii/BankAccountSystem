using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Services;

using DAL.Fake;
using DAL.EntityFramework;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Fake.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        { 
            
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberGenerator>();

            
            kernel.Bind<IRepository<DalAccount>>().To<AccountRepositoryEF>();
            kernel.Bind<IRepository<DalHolder>>().To<HoldertRepositoryEF>();
            
            /*
            kernel.Bind<IRepository<DalHolder>>().To<HolderRepository>();
            kernel.Bind<IRepository<DalAccount>>().To<AccountRepository>();    
            */
            

            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
            //kernel.Bind<IRepository>().To<FakeRepository>();


        }
    }
}
