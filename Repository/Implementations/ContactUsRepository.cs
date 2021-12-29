using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class ContactUsRepository: Repository<ContactUs>,IContactUsRepository
    {
        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructors
        public ContactUsRepository(AppDbContext db) : base(db)
        {
            this.db = db;

        }

        #endregion

        #region Methods
        public ContactUs GetContactUsByMessage(string message)
        {
            return db.ContactUs.Where(x=>x.Message.ToUpper().Trim() == message.ToUpper()).FirstOrDefault();

        }

        public bool IsContactUsExist(int ContactUsId)
        {
            var result = db.ContactUs.Any(x => x.ContactUsId == ContactUsId);
            return result;
        } 
        #endregion
    }
}
