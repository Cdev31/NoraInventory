
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IStateDAL
    {
        public Task<bool> create( StatesModel data );

        public Task<bool> update( StatesModel data );

        public Task<List<StatesModel>> findAll();

        public Task<StatesModel> findById( int id );
        
    }
}