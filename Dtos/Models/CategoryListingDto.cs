using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class CategoryListingDto :BaseDto
    {

        #region Constructors

        public CategoryListingDto()
        {

        }

        #endregion

        #region Fields
        
        public int CategoryId { get; set; }
        
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description Required")]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }

        #endregion

    }
}
