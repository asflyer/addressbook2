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
            int N = 1;//Порядковый номер удаляемой группы

            if (app.Groups.GroupExist())
            {
                app.Groups.Remove(N); //Указываем номер группы для удаления
            }
            else
            {
                GroupData group = new GroupData("a");
                app.Groups.Create(group);
                app.Groups.Remove(1);
            }
                
            
        }

    }
}
