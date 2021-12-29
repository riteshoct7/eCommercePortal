using Entities.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repository.Context;
using Repository.Implementations;
using System.Collections;

namespace RepositoryNUnitTests
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        #region Fields

        private Category objCategory1;
        private Category objCategory2;
        private DbContextOptions<AppDbContext> options;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "Temp").Options;
        } 

        #endregion

        #region Constructors

        public CategoryRepositoryTests()
        {
            objCategory1 = new Category()
            {
                CategoryId = 1,
                CategoryName = "TestCategory1",
                CategoryDescription = "TestDescription1",
                Enabled = true,
                CreatedDate = DateTime.UtcNow
            };
            objCategory2 = new Category()
            {
                CategoryId = 2,
                CategoryName = "TestCategory2",
                CategoryDescription = "TestDescription2",
                Enabled = true,
                CreatedDate = DateTime.UtcNow
            };
        }

        #endregion

        #region Methods

        [Test]
        [Order(1)] // defined order of calling
        public void SaveCategory()
        {           
            //act
            using (var context = new AppDbContext(options))
            {
                var unitOfWorkRepository = new UnitOfWorkRepository(context);
                unitOfWorkRepository.categoryRepository.Add(objCategory1);
                unitOfWorkRepository.SaveChanges();
            }

            //assert
            using (var context = new AppDbContext(options))
            {
                var objCategoryFromDb = context.Categories.FirstOrDefault(x => x.CategoryId == 1);
                Assert.AreEqual(objCategory1.CategoryId, objCategoryFromDb.CategoryId);
                Assert.AreEqual(objCategory1.CategoryName, objCategoryFromDb.CategoryName);
                Assert.AreEqual(objCategory1.CategoryDescription, objCategoryFromDb.CategoryDescription);
                Assert.AreEqual(objCategory1.Enabled, objCategoryFromDb.Enabled);
                Assert.AreEqual(objCategory1.CreatedDate, objCategoryFromDb.CreatedDate);
            }
        }

        [Test]
        [Order(2)]
        public void GetAll()
        {
            //arrange
            var expectedResult = new List<Category>() { objCategory1, objCategory2 };            
            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Categories.Add(objCategory1);
                context.Categories.Add(objCategory2); 
                context.SaveChanges();
            }

            //act
            List<Category> lstCategoryFromDb;
            using (var context = new AppDbContext(options))
            {
                var unitOfWorkRepository = new UnitOfWorkRepository(context);
                lstCategoryFromDb = unitOfWorkRepository.categoryRepository.GetAll().ToList();
            }
            
            //assert                      
            CollectionAssert.AreEqual(expectedResult, lstCategoryFromDb, new CategoryCompare());                        
        }

        #endregion

        #region Classes

        private class CategoryCompare : IComparer
        {
            public int Compare(object? x, object? y)
            {
                var category1 = (Category)x;
                var category2 = (Category)y;
                if (category1.CategoryId != category2.CategoryId)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        } 

        #endregion

    }
}
