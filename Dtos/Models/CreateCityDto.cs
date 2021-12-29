using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CreateCityDto:BaseDto    
    {

        #region Constructors

        public CreateCityDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Name Required")]
        public int StateId { get; set; }
        
        #endregion

    }
}
