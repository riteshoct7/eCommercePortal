using Dtos.ViewModels;
using Entities.Models;

namespace Services.Interfaces
{
    public interface IAccountService
    {

        #region Methods

        bool Register(RegisterViewModel user, string password);
        ApplicationUser Login(string userName, string password, bool rememberMe, bool lockOutOnFailure);
        //ApplicationUser GetUser(string userName);
        Task<bool> SignOut();

        #endregion

    }
}
