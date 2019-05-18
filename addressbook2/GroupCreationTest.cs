using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace web_addressbook_test
{
    [TestFixture]
    public class GroupCreationTests : TestBase

    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigationHelper.GoToGroupPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "Ccc"
            };
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }
        
    }
}