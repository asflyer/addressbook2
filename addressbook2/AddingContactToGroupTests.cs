using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace web_addressbook_test
{
    

    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() //Тест по добавлению контакта в ЗАДАННУЮ группу
        {
            app.Contacts.ContactExist();
            app.Groups.GroupExist();
            ContactData contact;
            GroupData group = GroupData.GetAll()[0];//Предполагаем, что нашего контакта нет в группе с индектом 0
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов
                     

            if (GroupData.GetAll().Count == oldList.Count) //То есть если в данную группу добавлены ВСЕ контакты
            {
                contact = new ContactData("321"); //Создаем новый контакт
                app.Contacts.AddContact(contact);

            }

            //Из всего списка контактов убираем те, которые входят в данную группу и берем первый из оставшихся
            contact = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts(); //Запоминаем старый список контактов

            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }

        private void GetID(ContactData contact)
        {
            app.Navigator.OpenHomePage();
            contact.ContactID = app.Driver.FindElement(By.TagName("input")).GetAttribute("value");
        }
    }
}
