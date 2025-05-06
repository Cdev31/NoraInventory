using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.NovaSys.BL.Interface
{
    public interface IProductBL
    {
        public Task<bool> create(CreateProductDTOs data);

        public List<Task<FindProductOuputDTOs>> findAll(FindAllByStateDTOs state);

        public Task<bool> update(UpdateProductDTOs data);

        public Task<FindProductOuputDTOs> findById(SetIdDTOs Id);

        public Task<bool> delete(SetIdDTOs Id);
    }
}