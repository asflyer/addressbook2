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

            app.Groups.Remove(0); //Указываем номер группы для удаления

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0); 
            
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
