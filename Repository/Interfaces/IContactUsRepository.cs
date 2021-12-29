using Entities.Models;

namespace Repository.Interfaces
{
    public interface IContactUsRepository:IRepository<ContactUs>
    {

        #region Methods

        ContactUs GetContactUsByMessage(string message);        
        bool IsContactUsExist(int ContactUsId);


        #endregion

    }
}
