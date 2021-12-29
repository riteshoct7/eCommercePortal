using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {

        #region Fields

        private readonly AppDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        #endregion

        #region Constructors

        public UnitOfWorkRepository(AppDbContext db)
        {
            this.db = db;                        
            categoryRepository = new CategoryRepository(db);
            contactUsRepository = new ContactUsRepository(db);
            countryRepository = new CountryRepository(db);
            stateRepository = new StateRepository(db);
            cityRepository = new CityRepository(db);            
        }

        public UnitOfWorkRepository(AppDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            storedProcedureRepository = new StoredProcedureRepository(db);
            categoryRepository = new CategoryRepository(db);
            contactUsRepository = new ContactUsRepository(db);
            countryRepository = new CountryRepository(db);
            stateRepository = new StateRepository(db);
            cityRepository  = new CityRepository(db);
            accountRepository = new AccountRepository(userManager, signInManager, roleManager);            
        }

        #endregion

        #region Methods

        public ICategoryRepository categoryRepository { get; private set; }
        public IStoredProcedureRepository storedProcedureRepository { get; private set; }
        public IAccountRepository accountRepository { get; private set; }
        public IContactUsRepository contactUsRepository { get; private set; }
        public ICountryRepository countryRepository { get; private set; }
        public IStateRepository stateRepository { get; private set; }
        public ICityRepository cityRepository { get; private set; }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }

        #endregion

    }
}
