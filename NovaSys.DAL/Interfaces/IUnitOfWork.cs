
namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}