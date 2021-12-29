using Dtos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Dtos.ViewModels
{
    public class EditCountryStateCityViewModel
    {

        #region Fields

        public IEnumerable<SelectListItem>? Countries { get; set; }

        public IEnumerable<SelectListItem>? States { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public UpdateCityDto UpdateCity { get; set; } 

        #endregion

    }
}
