using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbNovaContext dbContext;

        public UnitOfWork( DbNovaContext _dbContext ){
            dbContext = _dbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();  
        }
    }
}