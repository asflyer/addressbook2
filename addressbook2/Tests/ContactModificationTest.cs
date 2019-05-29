using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace web_addressbook_test
{
   
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            ContactData newData = new ContactData("454456"); //newData.Firstname
            newData.Middlename = "454456";
            newData.Lastname = "454456";
            int N = 1;//Указываем номер контакта для удаления 
            app.Navigator.OpenHomePage();


            if (app.Navigator.IsElementPresent(By.Name("entry")))
            {
                app.Contacts.Modify(N, newData); //порядковый номер записи на странице home
            }
            else
            {
                ContactData contact = new ContactData(""); //создаем контакт
                app.Contacts.AddContact(contact);
                app.Contacts.Modify(1, newData); //порядковый номер записи на странице home

            }


            
            

        }

    }
}
