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

    public class GroupModificationTest : GroupTestBase
    {
        [Test]

        public void GroupModificationTestCase()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null; 
            newData.Footer = "xxx";
            int N = 1;//Порядковый номер изменяемой группы начиная с нуля!!!

            app.Groups.GroupExist();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModifyed = oldGroups[N];
            //app.Groups.Modify(N, newData);
            app.Groups.Modify(toBeModifyed, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();

            toBeModifyed.Name = newData.Name;
            toBeModifyed.Header = newData.Header;
            toBeModifyed.Footer = newData.Footer;
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
