using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class ProductDAL: IProductDAL
    {
        readonly public DbNovaContext _dbContext;

        public ProductDAL(DbNovaContext dbContext){
            _dbContext = dbContext;
        }

        public Task<bool> create(ProductModel data)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductModel>> findAll(string state)
        {
            try
            {
                List<ProductModel> products = await _dbContext.ProductEN.ToListAsync();
                return products;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void update(ProductModel data)
        {
            throw new NotImplementedException();
        }
    }
}