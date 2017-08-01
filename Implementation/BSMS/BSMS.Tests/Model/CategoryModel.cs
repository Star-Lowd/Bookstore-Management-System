using System;
using NUnit.Framework;
namespace BSMS.Tests.Model
{
    [TestFixture]
    public class CategoryModel
    {
        BSMS.Models.CategoryModel _categorymodel;

        [SetUp]
        public void initialise()
        {
            _categorymodel = new Models.CategoryModel();
        }

        public BSMS.bsms.localhost.CATEGORY MockCat()
        {
            BSMS.bsms.localhost.CATEGORY cat = new bsms.localhost.CATEGORY();
            cat.NAME = "Test";
            cat.REFERENCE_KEY = "TestKey";
            cat.DESCRIPTION = "Unit Test Category";

            return cat;
        }
        [Test, Order(1)]
        public void TestGetAllMethod()
        {
            Assert.AreNotEqual(BSMS.Models.CategoryModel.GetAllCategory(), null);
        }
        
        [Test, Order(2)]
        public void TestAdd()
        {
            int intialSizeofCategory = BSMS.Models.CategoryModel.GetAllCategory().Count;
        
            bool added = BSMS.Models.CategoryModel.AddCategory(MockCat());
            int SizeofCategoryAfterOperation = BSMS.Models.CategoryModel.GetAllCategory().Count;
            Assert.AreEqual(true, added);
            Assert.AreNotEqual(intialSizeofCategory, SizeofCategoryAfterOperation);
            Assert.AreEqual(intialSizeofCategory+1, SizeofCategoryAfterOperation);

        }

        [Test, Order(3)]
        public void TestEdit()
        {
            int intialSizeofCategory = BSMS.Models.CategoryModel.GetAllCategory().Count;
            bsms.localhost.CATEGORY mockedCategory = BSMS.Models.CategoryModel.GetAllCategory()[intialSizeofCategory - 1];
            var catName = mockedCategory.NAME;
            var catReference = mockedCategory.REFERENCE_KEY;

            mockedCategory.NAME = "test Updated";
            mockedCategory.REFERENCE_KEY = "Key_Up";

            Models.CategoryModel.EditCategory(mockedCategory);
            //int intialSizeofCategory = BSMS.Models.CategoryModel.GetAllCategory().Count;
            bsms.localhost.CATEGORY updatedCategory = BSMS.Models.CategoryModel.GetAllCategory()[intialSizeofCategory - 1];
            Assert.AreNotEqual(catName, updatedCategory.NAME);
            Assert.AreNotEqual(catReference, updatedCategory.REFERENCE_KEY);
            Assert.AreEqual(mockedCategory.CATEGORYID, updatedCategory.CATEGORYID);

        }

        [Test, Order(4)]
        public void TestFilter()
        {
            int intialSizeofCategory = BSMS.Models.CategoryModel.GetAllCategory().Count;
            bsms.localhost.CATEGORY mockedCategory = BSMS.Models.CategoryModel.GetAllCategory()[intialSizeofCategory-1];
            bsms.localhost.CATEGORY fliteredCategory = BSMS.Models.CategoryModel.Fliter(mockedCategory.CATEGORYID);
            int SizeofCategoryAfterOperation = BSMS.Models.CategoryModel.GetAllCategory().Count;
            Assert.AreEqual(mockedCategory.NAME, fliteredCategory.NAME);
        }

        [Test, Order(5)]
        public void TestDelete()
        {
            int intialSizeofCategory = BSMS.Models.CategoryModel.GetAllCategory().Count;

            //Delete Mock Category
            bsms.localhost.CATEGORY fileredCategory = BSMS.Models.CategoryModel.GetAllCategory()[intialSizeofCategory - 1];
            BSMS.Models.CategoryModel.DeleteCategory(fileredCategory.CATEGORYID);
            int SizeofCategoryAfterOperation = BSMS.Models.CategoryModel.GetAllCategory().Count;
            Assert.AreNotEqual(intialSizeofCategory, SizeofCategoryAfterOperation);
            Assert.AreEqual(intialSizeofCategory - 1, SizeofCategoryAfterOperation);
            
        }

    }
}
