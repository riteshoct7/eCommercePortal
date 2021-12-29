using Entities.Models;

namespace Repository.Interfaces
{
    public interface IStateRepository :IRepository<State>
    {

        #region Methods

        State GetStateByStateName(string stateName);
        bool IsStateExist(string stateName, int StateId);
        bool IsStateExist(int StateId);
        IEnumerable<State> GetAllStates();

        #endregion

    }
}
