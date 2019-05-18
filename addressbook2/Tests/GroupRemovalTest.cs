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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.SelectGroup(1);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }

    }
}
