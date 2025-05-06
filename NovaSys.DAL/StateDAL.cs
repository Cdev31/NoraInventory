using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.DAL
{
    public class StateDAL : IStateDAL
    {
        readonly DbNovaContext _dbContext;
        public StateDAL(DbNovaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> create(StatesModel data)
        {
            try
            {
                var stateExits = await _dbContext.StateEN
                                .FirstOrDefaultAsync(s => s.stateName == data.stateName);

                if (stateExits != null) return false;

                await _dbContext.StateEN.AddAsync(data);
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatesModel>> findAll()
        {
            try
            {
                List<StatesModel> states = await _dbContext.StateEN.ToListAsync();
                return states;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> update(StatesModel data)
        {
            try
            {
                var stateExits = await _dbContext.StateEN
                                .FirstOrDefaultAsync(s => s.Id == data.Id);

                if (stateExits == null) return false;

                _dbContext.StateEN.Update(data);

                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}