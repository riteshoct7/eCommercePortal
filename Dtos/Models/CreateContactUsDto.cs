using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CreateContactUsDto : BaseDto
    {

        #region Constructors

        public CreateContactUsDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields
        
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject Required")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone Required")]
        [Phone(ErrorMessage = "Please Enter valid Phone")]
        public string Phone { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        #endregion

    }
}
