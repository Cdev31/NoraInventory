
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IProductDAL
    {
        public Task<List<ProductModel>> findAll(string state);

        public Task<bool> create( ProductModel data );

        public void update(ProductModel data);

        public void delete( int id);
    }
}