using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CreateStateDto : BaseDto
    {

        #region Constructors

        public CreateStateDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields
 
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public int CountryId { get; set; }
        
        #endregion

    }
}
