using Repository.Context;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {

        #region Fields

        private readonly AppDbContext db;
        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public UnitOfWorkService(AppDbContext db, IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.db = db;
            this.unitOfWorkRepository = unitOfWorkRepository;
            categoryService = new CategoryService(unitOfWorkRepository);
            storedProcedureService = new StoredProcedureService(unitOfWorkRepository);
            accountService= new AccountService(unitOfWorkRepository);
            contactUsService = new ContactUsService(unitOfWorkRepository);
            countryService = new CountryService(unitOfWorkRepository);
            stateService= new StateService(unitOfWorkRepository);
            cityService= new CityService(unitOfWorkRepository);
        }

        #endregion

        #region Methods

        public ICategoryService categoryService { get; private set; }
        public IStoredProcedureService storedProcedureService { get; private set; }
        public IAccountService accountService { get; private set; }
        public IContactUsService contactUsService { get; private set; }
        public ICountryService countryService { get; private set; }
        public IStateService stateService { get; private set; }
        public ICityService cityService { get; private set; }

        #endregion

    }
}
