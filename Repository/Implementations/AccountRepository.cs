using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {

        #region Fields

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        #endregion

        #region Constructors

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        #endregion

        #region Methods

        public ApplicationUser GetUser(string userName)
        {
            return userManager.FindByNameAsync(userName).Result;
        }

        public ApplicationUser Login(string userName, string password, bool rememberMe, bool lockOutOnFailure)
        {
            var result = signInManager.PasswordSignInAsync(userName, password, rememberMe, lockOutOnFailure).Result;
            if (result.Succeeded)
            {
                var user = userManager.FindByNameAsync(userName).Result;
                var roles = userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();
                return user;
            }
            return null;
        }

        public bool Register(ApplicationUser user, string password)
        {
            var result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {                
                //uncomment lines to add admin user
                if (!roleManager.RoleExistsAsync(Common.Constants.CustomerRoleTitle).Result)
                //if (!roleManager.RoleExistsAsync(Common.Constants.AdminRoleTitle).Result)
                    {
                    ApplicationRole objRole = new ApplicationRole();
                    objRole.Name = Common.Constants.CustomerRoleTitle;
                    objRole.NormalizedName = Common.Constants.CustomerRoleTitle;
                    objRole.Description = Common.Constants.CustomerRoleTitle;

                    //objRole.Name = Common.Constants.AdminRoleTitle;
                    //objRole.NormalizedName = Common.Constants.AdminRoleTitle;
                    //objRole.Description = Common.Constants.AdminRoleTitle;

                    var roleResult = roleManager.CreateAsync(objRole).Result;      
                    if(!roleResult.Succeeded)
                    {
                        return false;
                    }                    
                }
                var roleAssignmentResult = userManager.AddToRoleAsync(user, Common.Constants.CustomerRoleTitle).Result;
                //var roleAssignmentResult = userManager.AddToRoleAsync(user, Common.Constants.AdminRoleTitle).Result;
                if (roleAssignmentResult.Succeeded)
                {
                    return true;
                }                
            }
            return false;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
