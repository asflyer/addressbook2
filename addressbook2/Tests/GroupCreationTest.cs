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
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "Ccc"
            };
            app.Groups.Create(group);
            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            app.Groups.Create(group);
            
        }

    }
}