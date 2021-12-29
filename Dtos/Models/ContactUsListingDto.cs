using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class ContactUsListingDto : BaseDto
    {

        #region Constructors

        public ContactUsListingDto()
        {
            
        }

        #endregion

        #region Fields
        
        public int ContactUsId { get; set; }

        [Display(Name = "Subject")]        
        public string Subject { get; set; }

        [Display(Name = "Message")]        
        public string Message { get; set; }

        [Display(Name = "Email")]        
        public string Email { get; set; }

        [Display(Name = "Phone")]        
        public string Phone { get; set; }

        [Display(Name = "First Name")]        
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        #endregion

    }
}
