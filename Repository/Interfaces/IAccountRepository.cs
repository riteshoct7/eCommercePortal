using Entities.Models;

namespace Repository.Interfaces
{
    public interface IAccountRepository
    {

        #region Methods

        bool Register(ApplicationUser user, string password);
        ApplicationUser Login(string userName, string password, bool rememberMe, bool lockOutOnFailure);
        ApplicationUser GetUser(string userName);
        Task<bool> SignOut();

        #endregion

    }
}
