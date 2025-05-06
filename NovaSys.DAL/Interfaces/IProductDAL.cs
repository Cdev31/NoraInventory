
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IProductDAL
    {
        public Task<List<ProductModel>> findAll(int state);

         public Task<ProductModel> findById( int Id );

        public Task<bool> create( ProductModel data );

        public Task<bool> update(ProductModel data);

        public Task<bool> delete( int id);
    }
}