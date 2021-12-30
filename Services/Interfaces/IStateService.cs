using Dtos.Models;

namespace Services.Interfaces
{
    public interface IStateService
    {
        #region Methods

        #region Sync Methods

        bool Add(CreateStateDto model);
        bool Update(UpdateStateDto model);
        bool Remove(StateListingDto obj);
        bool Remove(object id);
        IEnumerable<StateListingDto> GetAll();
        IEnumerable<StateListingDto> GetAllStates();
        UpdateStateDto GetById(object id);
        StateListingDto GetStateByStateName(string stateName);
        bool IsStateExist(string stateName, int StateId);
        bool IsStateExist(int StateId);

        #endregion

        #region Async Methods

        #region Async Methods

        Task<StateListingDto> GetStateByStateNameAsync(string stateName);        
        Task<bool> IsStateExistAsync(string stateName, int StateId);        
        Task<bool> IsStateExistAsync(int StateId);
        Task<IEnumerable<StateListingDto>> GetAllStatesAsync();
        
        #endregion 

        #endregion 

        #endregion

    }
}
