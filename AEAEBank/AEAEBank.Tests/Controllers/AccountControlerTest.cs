using AEAEBank.Controllers;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using AEAEBank.Models;
using System.Threading.Tasks;
using AEAEBank.DAL;

namespace AEAEBank.Controllers.Tests
{
    [TestClass()]
    public class AccountControlerTest
    {
        public ApplicationDbContext appDb = new ApplicationDbContext();

        [TestMethod()]
        public void LoginTest()
        {
            AccountController controller = new AccountController();
            string returnUrl = "";
            ViewResult result = controller.Login(returnUrl) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void LoginTest1()
        {
            AccountController controller = new AccountController();
            LoginViewModel model = new LoginViewModel();
            string returnUrl = "";
            Task<ActionResult> result = controller.Login(model, returnUrl) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            AccountController controller = new AccountController();
            ViewResult result = controller.Register() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void SendEmailConfirmationTokenTest()
        {
            AccountController controller = new AccountController();
            string UserID = "1";
            string subject = "subject";
            Task<string> result = controller.SendEmailConfirmationToken(UserID, subject) as Task<string>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ConfirmEmailTest()
        {
            AccountController controller = new AccountController();
            string userId = "1";
            string code = "2345";
            Task<ActionResult> result = controller.ConfirmEmail(userId, code) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }
        // not yet tested
        //[TestMethod()]
        //public void IndexTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UserDetailsTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void IndexBankClientsTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void EditTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void EditUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void EditUserTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteConfirmedTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SearchBankClientsTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SearchBankClientsTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SearchAppUsersTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SearchAppUsersTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UserRolesTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UserRolesTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SendCodeTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SendCodeTest1()
        //{
        //    Assert.Fail();
        //}
    }
}

