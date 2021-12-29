namespace Dtos.Models
{
    public  class BaseDto
    {
        #region Constructors

        public BaseDto()
        {
            Enabled = true;
        } 

        #endregion

        #region Fields        

        public bool Enabled { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion
    }
}
