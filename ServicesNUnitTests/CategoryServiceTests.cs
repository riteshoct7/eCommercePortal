using Moq;
using NUnit.Framework;
using Repository.Interfaces;
using Services.Implementations;

namespace ServicesNUnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {

        #region Fields

        private Mock<IUnitOfWorkRepository> unitOfWorkRepositoryMock;
        private CategoryService objCatgeoryService; 

        #endregion

        #region Setup

        [SetUp]
        public void SetUp()
        {
            // objCatgeoryService  = new Mock<IUnitOfWorkRepository>();

        } 

        #endregion

        #region Constructors

        public CategoryServiceTests()
        {

        }

        #endregion

        #region Methods

        [Test]
        [Order(1)]
        public void SaveCategory()
        {

        }

        [Test]
        [Order(2)]
        public void GetAll()
        {

        }

        #endregion

    }
}
