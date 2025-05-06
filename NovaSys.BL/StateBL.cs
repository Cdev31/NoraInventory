using prueba_tec.NovaSys.BL.Interface;
using prueba_tec.NovaSys.DAL.Interfaces;
using prueba_tec.NovaSys.DTOs;
using prueba_tec.NovaSys.Models;

namespace prueba_tec.NovaSys.BL
{
    public class StateBL : IStateBL
    {
        readonly IStateDAL _stateDAL;
        readonly IUnitOfWork _unitOfWork;

        public StateBL( IStateDAL stateDAL, IUnitOfWork unitOfWork ){
            _stateDAL = stateDAL;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> create(CreateStateDTOs data)
        {
            StatesModel state = new StatesModel()
            {
                stateName = data.stateName,
                moduleName = data.moduleName
            };

            bool created = await _stateDAL.create( state );
            await _unitOfWork.SaveChangesAsync();

            return created;
        }

        public async Task<List<FindStatesOutputDTOs>> findAll()
        {
            List<StatesModel> states = await _stateDAL.findAll();
            List<FindStatesOutputDTOs> _states = new List<FindStatesOutputDTOs>();

            states.ForEach(
                s => {
                    FindStatesOutputDTOs state = new FindStatesOutputDTOs()
                    {
                        Id = s.Id,
                        stateName = s.stateName,
                        moduleName = s.moduleName
                    };
                    _states.Add( state );
                }
            );
            return _states;
        }

        public async Task<FindStatesOutputDTOs> findById(int id)
        {
            StatesModel state = await _stateDAL.findById( id );

            FindStatesOutputDTOs _state = new FindStatesOutputDTOs()
            {
                Id = state.Id,
                stateName = state.stateName,
                moduleName = state.moduleName
            };

            return _state;
        }

        public async Task<bool> update(UpdateStateDTOs data)
        {
            StatesModel state = new StatesModel()
            {
                Id = data.Id,
                stateName = data.stateName,
                moduleName = data.moduleName
            };

            bool updated = await _stateDAL.update( state );
            await _unitOfWork.SaveChangesAsync();

            return updated;
        }
    }
}