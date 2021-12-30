using Entities.Models;

namespace Repository.Interfaces
{
    public interface IStateRepository :IRepository<State>
    {
        #region Methods

        #region Sync Methods

        State GetStateByStateName(string stateName);
        bool IsStateExist(string stateName, int StateId);
        bool IsStateExist(int StateId);
        IEnumerable<State> GetAllStates();

        #endregion

        #region Async Methods

        Task<State> GetStateByStateNameAsync(string stateName);
        Task<bool> IsStateExistAsync(string stateName, int StateId);
        Task<bool> IsStateExistAsync(int StateId);
        Task<IEnumerable<State>> GetAllStatesAsync();

        #endregion 

        #endregion

    }
}
