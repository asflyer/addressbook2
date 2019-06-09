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
    public class GroupRemovalTests : AuthTestBase //Тесты где требуется логин наследуются от AuthTestBase. Где логин не требуется от TestBase напрямую
    {
        
        [Test]
        public void GroupRemovalTestCase()
        {
            //int N = 0;//Порядковый номер удаляемой группы начиная с нуля!!!


            app.Groups.GroupExist();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(0); //Указываем номер группы для удаления

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            

            oldGroups.RemoveAt(0); 
            
            Assert.AreEqual(oldGroups, newGroups); //Стандартный метод сравнения
            Equals(oldGroups, newGroups); //Метод созданный нами ( в GroupData )

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.ID, toBeRemoved.ID);
            }


        }

    }
}
