using BSMS.bsms.localhost;
using BSMS.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSMS.Tests.Model
{
    [TestClass]
    class AuthenticationModelTe
    {
        AuthenticationModel _iModel = new AuthenticationModel();
        private USER MockUser()
        {
            USER user = new USER();
            user.EMAIL = "test@test.com";
            user.FIRSTNAME = "Test";
            user.LASTNAME = "Test ";
            user.MIDDLENAME = "101";
            user.PASSWORDHASH = "12345678";
            user.ROLEID = 3;
            return AuthenticationModel.AddUser(user);
            //return user;
        }
        [TestMethod]
        public void AuthenticateUserTest()
        {
            USER user = MockUser();
            USER mock = AuthenticationModel.AuthenticateUser(user.USERNAME, user.PASSWORDHASH);
            Assert.AreEqual(user, mock);
        }

        //[TestMethod()]
        //public void GetStaffsTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UpdateUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void AddUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void EmailExistTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void VerifyUserHashTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void FindUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ChangePasswordTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void FindUserByEmailTest()
        //{
        //    Assert.Fail();
        //}
    }
}
