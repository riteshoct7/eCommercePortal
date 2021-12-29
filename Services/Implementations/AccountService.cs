using Dtos.ViewModels;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public AccountService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        public bool Register(RegisterViewModel user, string password)
        {
            ApplicationUser objAppUser = ObjectMapper.Mapper.Map<ApplicationUser>(user);
            objAppUser.UserName = user.Email;
            return unitOfWorkRepository.accountRepository.Register(objAppUser, password);
        }

        public ApplicationUser Login(string userName, string password, bool rememberMe, bool lockOutOnFailure)
        {
            return unitOfWorkRepository.accountRepository.Login(userName, password, rememberMe, lockOutOnFailure: false);
        }

        public Task<bool> SignOut()
        {
            return unitOfWorkRepository.accountRepository.SignOut();
        }

        #endregion

    }
}
