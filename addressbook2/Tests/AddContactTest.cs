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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            //Data Driven Testing - будем делать тестирование на основе данных. 
            //Тут генерируем 5 штук ContactData с параметрами ниже - получится 5 тестов с разными вх данными
            /* Для их запуска в консоли
               nunit3-console D:\c#projects\addressbook2\addressbook2\addressbook2.sln --test=web_addressbook_test.AddContactTest.AddContactTestCase
            */

            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++) 
            {
                contact.Add(new ContactData(GenerateRandomString(10)) //тут 30 - максимальное количество символов в генерируемой строке
                {
                    Lastname = GenerateRandomString (50),
                    Middlename = GenerateRandomString(50),
                    Nickname = GenerateRandomString(50),
                    Address = GenerateRandomString(50),
                    Company = GenerateRandomString(50),
                    HomePhone = GenerateRandomString(50),
                    MobilePhone = GenerateRandomString(50),
                    WorkPhone = GenerateRandomString(50),
                    Email1 = GenerateRandomString(50),
                    Email2 = GenerateRandomString(50),
                    Email3 = GenerateRandomString(50),
                    HomePage = GenerateRandomString(50),
                    NotesSecondary = GenerateRandomString(50),
                    AddressSecondary = GenerateRandomString(50),
                    SecondaryHome = GenerateRandomString(50),
                    
                });
            }

            return contact;
        }



        [Test, TestCaseSource("RandomGroupDataProvider")]
                          
        public void AddContactTestCase(ContactData contact)
        {
            /*/Тестовые данные пока не нужны, используем генератор
            ContactData contact = new ContactData("14565");
            contact.Middlename = "321";
            contact.Lastname = "1";
            contact.Nickname = "432144";
            //Остальные поля в функции FillContactData закомментировны. Будут тянуться по-умолчанию. 
            //Для заполнения других полей нужно создать конструктор в ContactData и добавить сюда заполняемые строки
            */
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
