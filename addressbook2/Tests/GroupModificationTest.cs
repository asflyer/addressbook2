using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace web_addressbook_test
{
    [TestFixture]

    public class GroupModificationTest : AuthTestBase
    {
        [Test]

        public void GroupModificationTestCase()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null; 
            newData.Footer = "xxx";
            int N = 1;//Порядковый номер изменяемой группы начиная с нуля!!!

            app.Groups.GroupExist();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeModifyed = oldGroups[N];
            app.Groups.Modify(N, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[N].Name = newData.Name;
            oldGroups[N].Header = newData.Header;
            oldGroups[N].Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if(group.ID == toBeModifyed.ID)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
