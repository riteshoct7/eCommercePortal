namespace Services.Interfaces
{
    public interface IUnitOfWorkService
    {

        #region Methods

        ICategoryService categoryService { get; }
        IStoredProcedureService storedProcedureService { get; }
        IAccountService accountService { get; }
        IContactUsService  contactUsService {get;}
        ICountryService countryService { get; }
        IStateService stateService { get; }
        ICityService cityService { get; }

        #endregion

    }
}
