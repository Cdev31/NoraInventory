
using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.NovaSys.BL.Interface
{
    public interface IClientBL
    {
        public Task<bool> create(CreateClientDTOs data);

        public List<Task<FindClientOutputDTOs>> findAll();

        public Task<bool> update(UpdateClientDTOs data);

        public Task<FindClientOutputDTOs> findById(SetIdDTOs Id);

        public Task<bool> delete(SetIdDTOs Id);
    }
}