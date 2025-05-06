
using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.NovaSys.BL.Interface
{
    public interface IOrderBL
    {
        public Task<bool> create( CreateOrderDTOs data );

        public Task<List<FindOutputOrderDTOs>> findAll();
    }
}