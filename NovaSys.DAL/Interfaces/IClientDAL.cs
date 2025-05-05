
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IClientDAL
    {
        public List<Task<ClientModel>> findAll();

        public Task<ClientModel> findById( int Id);
    }
}