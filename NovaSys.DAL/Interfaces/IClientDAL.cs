using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IClientDAL
    {
        public Task<List<ClientModel>> findAll();

        public Task<ClientModel> findById( int Id);

        public Task<bool> create( ClientModel data );

        public Task<bool> update( ClientModel data);

        public Task<bool> delete( int id);
    }
}