
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL.Interfaces
{
    public interface IOrderDAL
    {
        public Task<bool> create();

        public List<Task<OrderModel>> findAll();   
    }
}