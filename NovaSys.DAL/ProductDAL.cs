using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class ProductDAL : IProductDAL
    {
        readonly public DbNovaContext _dbContext;

        public ProductDAL(DbNovaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> create(ProductModel data)
        {
            try
            {
                var productExists = await _dbContext.ProductEN
                                    .FirstOrDefaultAsync(p => p.name == data.name);

                if (productExists != null) return false;

                await _dbContext.ProductEN.AddAsync(data);
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> delete(int id)
        {
            try
            {
                var productExists = await _dbContext.ProductEN
                                    .FirstOrDefaultAsync(p => p.Id == id);

                if (productExists == null) return false;

                _dbContext.ProductEN.Remove(productExists);
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<ProductModel> findById(int Id)
        {
            try
            {
                var productExits = await _dbContext.ProductEN.FirstOrDefaultAsync(p => p.Id == Id);

                return (productExits != null) ? productExits : new ProductModel();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> update(ProductModel data)
        {
            try
            {
                var productExists = await _dbContext.ProductEN
                                    .FirstOrDefaultAsync(p => p.Id == data.Id);

                if (productExists == null) return false;

                _dbContext.ProductEN.Update(data);
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            ;
        }
    }
}