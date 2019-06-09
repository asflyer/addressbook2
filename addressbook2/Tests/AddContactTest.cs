using System;
using System.Collections.Generic;
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
            //Тестовые данные
            ContactData contact = new ContactData("14565");
            contact.Middlename = "222";
            contact.Lastname = "333";
            contact.Nickname = "444";
            //Остальные поля в функции FillContactData закомментировны. Будут тянуться по-умолчанию. 
            //Для заполнения других полей нужно создать конструктор в ContactData и добавить сюда заполняемые строки

            List<ContactData> oldContacts = app.Contacts.GetContactList();//Читаем список контактов ДО теста

            app.Contacts.AddContact(contact);//ТЕСТ. Создает новый контакт
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(contact);//Добавляем в сохраненный массив данных созданный контакт (*)

            List<ContactData> newContacts = app.Contacts.GetContactList(); //Считываем список контактов ПОСЛЕ
            oldContacts.Sort(); //Сортируем оба списка одинаково (не суть как)
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);//Сравниваем массив контактов ДО+новый (*) и массив после 


        }
        
    }
}
