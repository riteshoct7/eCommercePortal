using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StateService : IStateService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public StateService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region  Sync Methods

        public bool Add(CreateStateDto model)
        {
            State objState = ObjectMapper.Mapper.Map<State>(model);
            unitOfWorkRepository.stateRepository.Add(objState);
            return unitOfWorkRepository.SaveChanges();            
        }

        public bool Update(UpdateStateDto model)
        {
            State objState = ObjectMapper.Mapper.Map<State>(model);
            unitOfWorkRepository.stateRepository.Update(objState);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(StateListingDto obj)
        {
            State objState = ObjectMapper.Mapper.Map<State>(obj);
            unitOfWorkRepository.stateRepository.Remove(objState);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(object id)
        {            
            unitOfWorkRepository.stateRepository.Remove(id);
            return unitOfWorkRepository.SaveChanges();
        }

        public IEnumerable<StateListingDto> GetAll()
        {
            var state = unitOfWorkRepository.stateRepository.GetAll();
            List<StateListingDto> lst = new List<StateListingDto>();
            foreach (var item in state)
            {
                lst.Add(ObjectMapper.Mapper.Map<StateListingDto>(item));
            }
            return lst;
        }

        public UpdateStateDto GetById(object id)
        {
            var state = unitOfWorkRepository.stateRepository.GetById(id);
            var stateDto = ObjectMapper.Mapper.Map<UpdateStateDto>(state);
            return stateDto;
        }

        public StateListingDto GetStateByStateName(string stateName)
        {
            var state = unitOfWorkRepository.stateRepository.GetStateByStateName(stateName);
            var stateDto = ObjectMapper.Mapper.Map<StateListingDto>(state);
            return stateDto;
        }

        public bool IsStateExist(string stateName, int StateId)
        {
            return unitOfWorkRepository.stateRepository.IsStateExist(stateName, StateId);
        }

        public bool IsStateExist(int StateId)
        {
            return unitOfWorkRepository.stateRepository.IsStateExist(StateId);
        }

        public IEnumerable<StateListingDto> GetAllStates()
        {     
            var states = unitOfWorkRepository.stateRepository.GetAllStates();
            var lstStatesDTO = new List<StateListingDto>();
            foreach (var item in states)
            {
                lstStatesDTO.Add(ObjectMapper.Mapper.Map<StateListingDto>(item));
            }
            return lstStatesDTO;
        }

        #endregion

        #region Async Methods

        public async Task<StateListingDto> GetStateByStateNameAsync(string stateName)
        {
            var state = await unitOfWorkRepository.stateRepository.GetStateByStateNameAsync(stateName);
            var stateDto = ObjectMapper.Mapper.Map<StateListingDto>(state);
            return stateDto;
        }

        public async Task<bool> IsStateExistAsync(string stateName, int StateId)
        {
            var result = await unitOfWorkRepository.stateRepository.IsStateExistAsync(stateName,StateId);
            return result;
        }

        public async Task<bool> IsStateExistAsync(int StateId)
        {
            var result = await unitOfWorkRepository.stateRepository.IsStateExistAsync(StateId);
            return result;
        }

        public async Task<IEnumerable<StateListingDto>> GetAllStatesAsync()
        {
            {
                var states = await unitOfWorkRepository.stateRepository.GetAllStatesAsync();
                var lstStatesDTO = new List<StateListingDto>();
                foreach (var item in states)
                {
                    lstStatesDTO.Add(ObjectMapper.Mapper.Map<StateListingDto>(item));
                }
                return lstStatesDTO;
            }
        }

        #endregion

    }
}
