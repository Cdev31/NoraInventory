using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class ClientDAL : IClientDAL
    {
        readonly DbNovaContext _dbContext;

        public ClientDAL(DbNovaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> create(ClientModel data)
        {
            try
            {
                var existClient = await _dbContext.ClientEN
                                 .Where(c => c.email == data.email)
                                 .FirstOrDefaultAsync();

                if (existClient == null)
                {
                    await _dbContext.AddAsync(data);
                    return true;

                }
                else return false;
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
                var existClient = await _dbContext.ClientEN
                                   .Where(c => c.Id == id)
                                   .FirstOrDefaultAsync();

                if (existClient != null)
                {
                    _dbContext.ClientEN.Remove(existClient);
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClientModel>> findAll()
        {
            try
            {
                List<ClientModel> clients = await _dbContext.ClientEN.ToListAsync();

                return clients;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClientModel> findById(int Id)
        {
            try
            {
                var existClient = await _dbContext.ClientEN
                                     .Where(c => c.Id == Id)
                                     .FirstOrDefaultAsync();

                return (existClient == null) ? new ClientModel() : existClient;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> update(ClientModel data)
        {
            try
            {
                var existClient = await _dbContext.ClientEN
                                  .Where(c => c.Id == data.Id)
                                  .FirstOrDefaultAsync();

                if (existClient != null)
                {
                    _dbContext.ClientEN.Update(data);
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}