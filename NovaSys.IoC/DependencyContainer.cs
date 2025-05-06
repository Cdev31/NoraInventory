using prueba_tec.NovaSys.BL;
using prueba_tec.NovaSys.DAL;

namespace prueba_tec.NovaSys.IoC
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddNovaInventoryDependencies(this IServiceCollection service, IConfiguration config)
        {

            service.AddDALDependencies(config);
            service.AddBLDependencies();

            return service;
        }
    }
}