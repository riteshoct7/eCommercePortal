namespace Entities.Models
{
    public class BaseEntity
    {

        #region Constructors
        public BaseEntity()
        {
            Enabled = true;
        } 

        #endregion

        #region Fields

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Enabled { get; set; } 

        #endregion

    }
}
