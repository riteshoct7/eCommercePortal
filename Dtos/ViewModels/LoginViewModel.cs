using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public class LoginViewModel
    {

        #region Fields

        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }

        [Display(Name = "Rememeber Me?")]
        public bool RememberMe { get; set; }

        #endregion

    }
}
