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
            int N = 1;//Указываем номер группы для изменения
            app.Navigator.GoToGroupPage();//Чтобы смотреть на этой странице существуют-ли группы

            
            if (app.Navigator.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Remove(N);//Будет удалена N-ая группа. Если такой нет - тест упадет.
            }
            else //В случае, если было задано N=1, а групп нет совсем - создаем.
            {
                GroupData group = new GroupData(" ");
                app.Groups.Create(group);
                app.Groups.Remove(1);

            }



        }

    }
}
