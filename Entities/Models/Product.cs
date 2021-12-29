using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product : BaseEntity
    {

        #region Constructors

        public Product()
        {
            Enabled = true;
        }

        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Productid { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Qty Available")]
        [Required(ErrorMessage = "Qty Available Required")]
        public int QtyAvailable { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price Required")]
        public double UnitPrice { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        #endregion

    }
}
