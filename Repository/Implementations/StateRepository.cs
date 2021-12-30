using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class StateRepository :Repository<State>,IStateRepository
    {

        #region Fields

        private readonly AppDbContext db; 

        #endregion

        #region Constructors

        public StateRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public State GetStateByStateName(string stateName)
        {
            return db.States.Where(x => x.StateName.ToUpper().Trim() == stateName.ToUpper().Trim()).FirstOrDefault();
        }

        public bool IsStateExist(string stateName, int StateId)
        {
            var result = db.States.Any(x => x.StateName.ToUpper().Trim() == stateName.ToUpper().Trim() && x.StateId != StateId);
            return result;
        }

        public bool IsStateExist(int StateId)
        {
            var result = db.States.Any(x => x.StateId == StateId);
            return result;
        }

        public IEnumerable<State> GetAllStates()
        {
            return db.States.Include(x => x.Country).ToList();
        }

        #endregion

        #region Async Methods

        public async Task<State> GetStateByStateNameAsync(string stateName) 
        {
            dynamic  result =  db.States.Where(x => x.StateName.ToUpper().Trim() == stateName.ToUpper().Trim()).FirstOrDefault();
            return await result;
        }

        public async Task<bool> IsStateExistAsync(string stateName, int StateId) 
        {
            dynamic result = db.States.Any(x => x.StateName.ToUpper().Trim() == stateName.ToUpper().Trim() && x.StateId != StateId);
            return await result;
        }

        public async Task<bool> IsStateExistAsync(int StateId) 
        {
            dynamic result = db.States.Any(x => x.StateId == StateId);
            return await result;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync() 
        {
            dynamic result =  db.States.Include(x => x.Country).ToList();
             return await result;
        }

        #endregion
        
        #endregion

    }
}
