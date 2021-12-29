using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Category : BaseEntity
    {

        #region Constructors

        public Category()
        {
            Enabled = true;
        } 

        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [Display(Name = "Category Name")]

        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Description Required")]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; } 

        public List<Product> Products { get; set; }

        #endregion

    }
}
