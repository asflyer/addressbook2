using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace web_addressbook_test 
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        
        [Test]
        public void GroupRemovalTestCase()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }

    }
}
