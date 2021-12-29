using Dtos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dtos.ViewModels
{
    public class UpdateCountryStateViewModel
    {
        #region Fields

        public IEnumerable<SelectListItem>? Countries { get; set; }

        public UpdateStateDto UpdateState { get; set; } 

        #endregion
    }
}
