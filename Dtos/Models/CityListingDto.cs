using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CityListingDto : BaseDto
    {

        #region Constructors

        public CityListingDto()
        {            
        }

        #endregion

        #region Fields

        public int CityId { get; set; }

        [Display(Name = "City Name")]        
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }
        
        public int StateId { get; set; }

        public StateListingDto State { get; set; }

        #endregion

    }
}
