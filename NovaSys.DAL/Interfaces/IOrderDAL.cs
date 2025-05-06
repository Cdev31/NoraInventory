
using prueba_tec.NovaSys.DTOs;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IOrderDAL
    {
        public Task<bool> create( CreateOrderDTOs data );

        public Task<List<OrderModel>> findAll();   
    }
}