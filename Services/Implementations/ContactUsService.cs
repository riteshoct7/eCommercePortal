using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ContactUsService : IContactUsService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository; 

        #endregion

        #region Constructors

        public ContactUsService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        public IEnumerable<ContactUsListingDto> GetAll()
        {
            var contactUs = unitOfWorkRepository.contactUsRepository.GetAll();
            var contactUsDto = new List<ContactUsListingDto>();
            foreach (var item in contactUs)
            {
                contactUsDto.Add(ObjectMapper.Mapper.Map<ContactUsListingDto>(item));                
            }
            return contactUsDto;            
        }

        public ContactUsListingDto GetById(object id)
        {
            var contactUs = unitOfWorkRepository.contactUsRepository.GetById(id);
            var contactUsDto = ObjectMapper.Mapper.Map<ContactUsListingDto>(contactUs);
            return contactUsDto;
        }

        public bool Add(CreateContactUsDto obj)
        {            
            var contactUs  =  ObjectMapper.Mapper.Map<ContactUs>(obj);
            unitOfWorkRepository.contactUsRepository.Add(contactUs);            
            return unitOfWorkRepository.SaveChanges();            
        }

        public bool Update(UpdateContactUsDto obj)
        {
            var contactUs = ObjectMapper.Mapper.Map<ContactUs>(obj);
            unitOfWorkRepository.contactUsRepository.Update(contactUs);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(ContactUsListingDto obj)
        {
            var contactUs = ObjectMapper.Mapper.Map<ContactUs>(obj);
            unitOfWorkRepository.contactUsRepository.Remove(contactUs);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(object id)
        {            
            unitOfWorkRepository.contactUsRepository.Remove(id);
            return unitOfWorkRepository.SaveChanges();
        }

        public ContactUsListingDto GetContactUsByMessage(string message)
        {
            var contactUs = unitOfWorkRepository.contactUsRepository.GetContactUsByMessage(message);
            var contactUsDto = ObjectMapper.Mapper.Map<ContactUsListingDto>(contactUs);
            return contactUsDto;            
        }

        public bool IsContactUsExist(int ContactUsId)
        {
            return unitOfWorkRepository.contactUsRepository.IsContactUsExist(ContactUsId);
        } 

        #endregion

    }
}
