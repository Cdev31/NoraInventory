
using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.NovaSys.BL.Interface
{
    public interface IStateBL
    {
        public Task<bool> create( CreateStateDTOs data );

        public Task<bool> update( UpdateStateDTOs data );

        public List<Task<FindStatesOutputDTOs>> findAll();

    }
}