using prueba_tec.NovaSys.BL.Interface;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;
using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.NovaSys.BL
{
    public class ClientBL : IClientBL
    {
        readonly IClientDAL _clientDAL;
        readonly IUnitOfWork _unitOfWork;

        public ClientBL( IClientDAL clientDAL, IUnitOfWork unitOfWork ){
            _clientDAL = clientDAL;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> create(CreateClientDTOs data)
        {
           ClientModel client = new ClientModel()
           {
             firstname = data.firstname,
             surname = data.surname,
             email = data.email,
             state = data.state
           };

           bool created = await _clientDAL.create( client );
           await _unitOfWork.SaveChangesAsync();

           return created;
        }

        public async Task<bool> delete(SetIdDTOs Id)
        {
            bool deleted = await _clientDAL.delete( Id.Id );
            await _unitOfWork.SaveChangesAsync();
            return deleted;
        }

        public async Task<List<FindClientOutputDTOs>> findAll()
        {
            List<FindClientOutputDTOs> _clients = new List<FindClientOutputDTOs>();
            List<ClientModel> clients = await _clientDAL.findAll();

            clients.ForEach(
                c => {
                    var newClient = new FindClientOutputDTOs()
                    {
                        Id = c.Id,
                        firstname = c.firstname,
                        surname = c.surname,
                        email = c.email,
                        state = c.clientState.stateName
                    };
                    _clients.Add(newClient);
                }
            );

            return _clients;

        }

        public async Task<FindClientOutputDTOs> findById(SetIdDTOs Id)
        {
            ClientModel client = await _clientDAL.findById( Id.Id );

            FindClientOutputDTOs _client = new FindClientOutputDTOs()
            {
                Id = client.Id,
                firstname = client.firstname,
                surname = client.surname,
                email = client.surname,
                state = client.clientState.stateName
            };

            return _client;
        }

        public async Task<bool> update(UpdateClientDTOs data)
        {
            ClientModel client = new ClientModel()
            {
                Id = data.Id,
                firstname = data.firstname,
                surname = data.surname,
                email = data.email,
                state = data.state
            };
            bool updated = await _clientDAL.update( client );

            return updated;
        }
    }
}