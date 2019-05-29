using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace web_addressbook_test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);


            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

            


        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            //Thread.Sleep(100); //Костыль - иначе падает при массовом запуске
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]//Тест для того, чтобы проверить, что наши проверки работают
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a")//группа с одинарной кавычкой не создается (багуля) - new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };
            //Thread.Sleep(100); //Костыль - иначе падает при массовом запуске
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

    }
}