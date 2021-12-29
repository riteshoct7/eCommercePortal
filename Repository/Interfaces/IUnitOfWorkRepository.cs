namespace Repository.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {

        #region Methods

        ICategoryRepository categoryRepository { get; }
        IStoredProcedureRepository storedProcedureRepository { get; }
        IAccountRepository accountRepository { get; }
        IContactUsRepository contactUsRepository { get; }
        ICountryRepository countryRepository { get; }
        IStateRepository stateRepository { get; }   
        ICityRepository cityRepository { get; }

        bool SaveChanges();

        #endregion

    }
}
