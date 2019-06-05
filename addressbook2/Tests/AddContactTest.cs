using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace web_addressbook_test
{
    [TestFixture]
    public class AddContactTest : AuthTestBase
    {
        [Test]
        public void AddContactTestCase()
        {
            ContactData contact = new ContactData("111");
            contact.Middlename = "222";
            contact.Lastname = "333";
            contact.Nickname = "444";
            //Остальные поля в функции FillContactData закомментировны. Будут тянуться по-умолчанию. 
            //Для заполнения других полей нужно создать конструктор в ContactData и добавить сюда заполняемые строки
            app.Contacts.AddContact(contact);

               
        }
        
    }
}
