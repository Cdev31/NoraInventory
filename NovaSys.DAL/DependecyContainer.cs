using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public static class DependecyContainer
    {
         public static IServiceCollection AddDALDependencies( this IServiceCollection service, IConfiguration config ){
            
            service.AddDbContext<DbNovaContext>( options => options.UseSqlServer( config.GetConnectionString("conn")));

            service.AddScoped<IProductDAL, ProductDAL>();
            service.AddScoped<IClientDAL, ClientDAL>();
            service.AddScoped<IOrderDAL, OrderDAL>();
            service.AddScoped<IStateDAL, StateDAL>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}