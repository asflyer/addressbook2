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
            int N = 1;//Указываем номер группы для изменения и новые значения в newData

            app.Navigator.GoToGroupPage();//Чтобы смотреть на этой странице существуют-ли группы
            
            if (app.Navigator.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Modify(N, newData);//Будет изменена N-ая группа. Если такой нет - тест упадет. 
            }
            else //В случае, если было задано N=1, а групп нет совсем - создаем.
            {
                GroupData group = new GroupData(" ");
              
                app.Groups.Create(group);
                app.Groups.Modify(1, newData);//Если создана тольо одна, то это будет всегда 1ая группа

            }


        }

    }
}
