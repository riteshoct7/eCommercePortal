using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CreateCountryDto :BaseDto
    {

        #region Constructors

        public CreateCountryDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields
        
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
