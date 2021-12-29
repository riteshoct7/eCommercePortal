using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class UpdateCountryDto:BaseDto
    {

        #region Constructors

        public UpdateCountryDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Required(ErrorMessage = "CountryId Required")]
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }
        
        #endregion

    }
}
