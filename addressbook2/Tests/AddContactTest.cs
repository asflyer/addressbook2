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
    public class AddContactTest : TestBase
    {
        [Test]
        public void AddContactTestCase()
        {
            ContactData contact = new ContactData("559958");
            contact.Middlename = "ggg";
            contact.Lastname = "ttt";
            contact.Nickname = "dfghjkl";
            //Остальные поля в функции FillContactData закомментировны. Будут тянуться по-умолчанию. 
            //Для заполнения других полей нужно создать конструктор в ContactData и добавить сюда заполняемые строки
            app.Contacts.AddContact(contact);

               
        }
        
    }
}
