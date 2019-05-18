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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "Ccc"
            };
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }
        
    }
}