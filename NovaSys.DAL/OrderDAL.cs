using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.DTOs;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class OrderDAL : IOrderDAL
    {
        readonly DbNovaContext _dbContext;

        public OrderDAL( DbNovaContext dbContext ){
            _dbContext = dbContext;
        }
        public async Task<bool> create(CreateOrderDTOs data)
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    var newOrder = new OrderModel
                    {
                        state = data.state,
                        client = data.client
                    };

                    await _dbContext.OrderEN.AddAsync(newOrder);
                    await _dbContext.SaveChangesAsync();

                    foreach (var p in data.products)
                    {
                        var product = new ProductOrderModel
                        {
                            product = p.Id,
                            order = newOrder.Id,
                            quantity = p.quantity
                        };

                        await _dbContext.ProductOrderEN.AddAsync(product);
                    }

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true; 
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false; 
                }
            });
        }


        public async Task<List<OrderModel>> findAll()
        {
            try
            {
                List<OrderModel> orders = await _dbContext.OrderEN
                                          .Include( po => po.Products )
                                             .ThenInclude( p => p.productID )
                                          .Include( po => po.clientId )
                                          .ToListAsync();
                return orders;
            }
            catch (SqlException ex)
            {
                throw new Exception( ex.Message );
            }
        }
    }
}