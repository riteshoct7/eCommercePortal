using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class StateListingDto : BaseDto
    {

        #region Constructors

        public StateListingDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields
        
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }
        
        public int CountryId { get; set; }

        public CountryListingDto Country { get; set; }

        public List<CityListingDto> City { get; set; }

        #endregion

    }
}
