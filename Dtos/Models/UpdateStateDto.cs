using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class UpdateStateDto:BaseDto     
    {

        #region Constructors

        public UpdateStateDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Required(ErrorMessage = "StateId Required")]
        public int StateId { get; set; }

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
