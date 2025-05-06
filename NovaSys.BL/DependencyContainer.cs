using Microsoft.Extensions.DependencyInjection;
using prueba_tec.NovaSys.BL.Interface;

namespace prueba_tec.NovaSys.BL
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductBL, ProductBL>();
            services.AddTransient<IOrderBL, OrderBL>();
            services.AddTransient<IClientBL, ClientBL>();
            services.AddTransient<IStateBL, StateBL>();
            return services;
        }
    }
}