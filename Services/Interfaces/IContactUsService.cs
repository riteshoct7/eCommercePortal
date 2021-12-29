using Dtos.Models;

namespace Services.Interfaces
{
    public interface IContactUsService
    {

        #region Methods

        IEnumerable<ContactUsListingDto> GetAll();
        ContactUsListingDto GetById(object id);
        bool Add(CreateContactUsDto obj);
        bool Update(UpdateContactUsDto obj);
        bool Remove(ContactUsListingDto obj);
        bool Remove(object id);
        ContactUsListingDto GetContactUsByMessage(string message);
        bool IsContactUsExist(int ContactUsId);

        #endregion

    }
}
