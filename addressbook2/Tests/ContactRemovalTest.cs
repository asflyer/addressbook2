using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            int N = 1;//Указываем номер контакта для удаления 
            app.Navigator.OpenHomePage();

            if (app.Navigator.IsElementPresent(By.Name("entry")))
            {
                app.Contacts.RemoveContact(N);//указывается порядковый номер записи в таблице на странице home
            }
            else
            {
                ContactData contact = new ContactData(""); //создаем контакт
                app.Contacts.AddContact(contact);
                app.Contacts.RemoveContact(1);

            }

            

        }
        
    }
}
