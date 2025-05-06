using prueba_tec.NovaSys.BL.Interface;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.DTOs;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.BL
{
    public class OrderBL : IOrderBL
    {
        readonly IOrderDAL _orderDAL;

        public OrderBL( IOrderDAL orderDAL ){
            _orderDAL = orderDAL;
        }

        public async Task<bool> create(CreateOrderDTOs data)
        {
            bool created = await _orderDAL.create( data );
            return created;
        }

        public async Task<List<FindOutputOrderDTOs>> findAll()
        {
            List<OrderModel> orders = await _orderDAL.findAll();

            List<FindOutputOrderDTOs> _orders = new List<FindOutputOrderDTOs>();

            orders.ForEach(
                o => {
                    List<ProductModel> products = new List<ProductModel>();

                    o.Products.ForEach( p => products.Add(p.productID) );

                    FindOutputOrderDTOs order = new FindOutputOrderDTOs()
                    {
                        Id = o.Id,
                        client = o.clientId,
                        products = products
                    };

                    _orders.Add( order );
                }
            );
            return _orders;
        }
    }
}