using Dtos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dtos.ViewModels
{
    public class CreateCountryStateViewModel
    {

        #region Fields

        public IEnumerable<SelectListItem>? Countries { get; set; }
        public CreateStateDto State { get; set; }         

        #endregion

    }

}
