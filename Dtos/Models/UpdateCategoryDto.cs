using System.ComponentModel.DataAnnotations;

namespace Dtos.Models
{
    public class UpdateCategoryDto :BaseDto
    {

        #region Constructors

        public UpdateCategoryDto()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Required(ErrorMessage = "CategoryId Required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description Required")]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }

        #endregion

    }
}
