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

    }
}
