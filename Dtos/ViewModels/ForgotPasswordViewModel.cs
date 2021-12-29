using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public class ForgotPasswordViewModel
    {

        #region Fields

        [Display(Name ="Email")]
        [EmailAddress]
        [Required(ErrorMessage ="Email Required")]
        public string Email { get; set; }


        #endregion

    }
}
