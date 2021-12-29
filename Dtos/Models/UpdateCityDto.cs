using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class UpdateCityDto:BaseDto
    {

        #region Constructors

        public UpdateCityDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Required(ErrorMessage = "CityId Required")]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Required")]
        public int StateId { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public int CountryId { get; set; }

        #endregion

    }
}
