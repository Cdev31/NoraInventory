using Microsoft.EntityFrameworkCore;

namespace prueba_tec.NovaSys.DAL
{
    public static class DependecyContainer
    {
         public static IServiceCollection AddDALDependencies( this IServiceCollection service, IConfiguration config ){
            
            service.AddDbContext<ContextDB>( options => options.UseSqlServer( config.GetConnectionString("conn")));

            service.AddScoped<IProductDAL, ProductDAL>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}