using Dapper;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StoredProcedureService : IStoredProcedureService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public StoredProcedureService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            return unitOfWorkRepository.storedProcedureRepository.Single<T>(procedureName, param);            
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            unitOfWorkRepository.storedProcedureRepository.Execute(procedureName, param);            
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            return unitOfWorkRepository.storedProcedureRepository.OneRecord<T>(procedureName, param);            
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            return unitOfWorkRepository.storedProcedureRepository.List<T>(procedureName, param);          
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            return unitOfWorkRepository.storedProcedureRepository.List<T1,T2>(procedureName, param);            
        }

        #endregion

    }
}
