using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CountryListingDto : BaseDto
    {

        #region Constructors

        public CountryListingDto()
        {
            
        }

        #endregion

        #region Fields
        
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]        
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        public List<StateListingDto> States { get; set; }

        #endregion

    }
}
