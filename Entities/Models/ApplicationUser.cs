using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ApplicationUser:IdentityUser<int>
    {

        #region Constructors

        public ApplicationUser()
        {

        } 

        #endregion

        #region Fields

        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }

        #endregion

    }
}
