using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

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

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));//Открываем файл
            Excel.Worksheet sheet = wb.ActiveSheet;//При открытии сразу попадаем на активную страницу (лист)
            Excel.Range range = sheet.UsedRange;//Находим прямоугольник, который содержит какие-то данные
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Middlename = range.Cells[i, 2].Value,
                    Lastname = range.Cells[i, 3].Value,
                    Nickname = range.Cells[i, 5].Value,
                    Title = range.Cells[i, 5].Value,
                    Company = range.Cells[i, 6].Value,
                    Address = range.Cells[i, 7].Value,
                    HomePhone = range.Cells[i, 8].Value,
                    MobilePhone = range.Cells[i, 9].Value,
                    WorkPhone = range.Cells[i, 10].Value,
                    FaxPhone = range.Cells[i, 11].Value,
                    Email1 = range.Cells[i, 12].Value,
                    Email2 = range.Cells[i, 13].Value,
                    Email3 = range.Cells[i, 14].Value,
                    HomePage = range.Cells[i, 15].Value,
                    AddressSecondary = range.Cells[i, 16].Value,
                    SecondaryHome = range.Cells[i, 17].Value,
                    NotesSecondary = range.Cells[i, 18].Value//нужна ли тут запятая?
                });

            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) //Явно указываем какого типа возвращаемый объект
                new XmlSerializer(typeof(List<ContactData>))//Читаем данные типа GroupData
                .Deserialize(new StreamReader(@"contacts.xml"));//Из файла с именем groups.xml
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    Middlename = parts[1],
                    Lastname = parts[2],
                    Nickname = parts[3],
                    Title = parts[4],
                    Company = parts[5],
                    Address = parts[6],
                    HomePhone = parts[7],
                    MobilePhone = parts[8],
                    WorkPhone = parts[9],
                    FaxPhone = parts[10],
                    Email1 = parts[11],
                    Email2 = parts[12],
                    Email3 = parts[13],
                    HomePage = parts[14],
                    AddressSecondary = parts[15],
                    SecondaryHome = parts[16],
                    NotesSecondary = parts[17]
                });
            }
            return contacts;
        }

        //[Test, TestCaseSource("ContactDataFromCsvFile")]
        [Test, TestCaseSource("ContactDataFromExcelFile")]
                          
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
