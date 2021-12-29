using Dtos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public class CreateCountryStateCityViewModel
    {
        
        #region Fields

        public IEnumerable<SelectListItem>? Countries { get; set; }

        public IEnumerable<SelectListItem>? States { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public int CountryId { get; set; }

        public CreateCityDto City { get; set; } 

        #endregion

    }
}
