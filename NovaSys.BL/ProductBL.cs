using prueba_tec.NovaSys.BL.Interface;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.DTOs;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.BL
{
    public class ProductBL : IProductBL
    {
        readonly IProductDAL _productDAL;
        readonly IUnitOfWork _unitOfWork;

        public ProductBL( IProductDAL productDAL, IUnitOfWork unitOfWork ){
            _productDAL = productDAL;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> create(CreateProductDTOs data)
        {
           ProductModel product = new ProductModel()
           {
             name = data.name,
             price = data.price,
             stock = data.stock,
             state = data.state,
             description = data.description
           };

           bool createProduct = await _productDAL.create( product );
           await _unitOfWork.SaveChangesAsync();

           return createProduct;
        }

        public async Task<bool> delete(SetIdDTOs Id)
        {
            bool deleted = await _productDAL.delete( Id.Id );
            await _unitOfWork.SaveChangesAsync();
            return deleted;
        }

        public async Task<List<FindProductOuputDTOs>> findAll(FindAllByStateDTOs state)
        {
           List<FindProductOuputDTOs> _products = new List<FindProductOuputDTOs>();
            List<ProductModel> products = await _productDAL.findAll( state.state );

            products.ForEach(
                p => {
                    var newProduct = new FindProductOuputDTOs()
                    {
                        Id = p.Id,
                        name = p.name,
                        price = p.price,
                        stock = p.stock,
                        state = p.productState.stateName,
                        description = p.description
                    };
                    _products.Add(newProduct);
                }
            );

            return _products;
        }

        public async Task<FindProductOuputDTOs> findById(SetIdDTOs Id)
        {
            ProductModel _product = await _productDAL.findById( Id.Id );
            FindProductOuputDTOs product = new FindProductOuputDTOs()
            {
                Id = _product.Id,
                name = _product.name,
                price = _product.price,
                stock = _product.stock,
                state = _product.productState.stateName,
                description = _product.description
            };

            return product;
        }

        public async Task<bool> update(UpdateProductDTOs data)
        {
            ProductModel product = new ProductModel()
            {
                Id = data.Id,
                name = data.name,
                price = data.price,
                state = data.state,
                description = data.description
            };

            bool updated = await _productDAL.update( product );
            return updated;
        }
    }
}