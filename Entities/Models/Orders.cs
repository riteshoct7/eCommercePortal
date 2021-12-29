using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Orders: BaseEntity
    {

        #region Constructors

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        #endregion

        #region Fields

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "Order Date Required")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "TotalQuantity")]
        [Required(ErrorMessage = "Total Quantity Required")]
        public int TotalQuantity { get; set; } 

        #endregion

    }
}
