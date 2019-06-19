using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_addressbook_test
{
   
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            ContactData newData = new ContactData("4646"); //newData.Firstname
            //newData.Middlename = "56";
            newData.Lastname = "53126";
            int N = 0;//порядковый номер записи на странице home  начиная с нуля!!! Работало с GetContactList

            app.Contacts.ContactExist();
            List<ContactData> oldContacts = ContactData.GetAll();

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            ContactData toBeModifyed = oldContacts[N];
            app.Contacts.Modify(toBeModifyed, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            //List<ContactData> newContacts = app.Contacts.GetContactList(); //Считываем список контактов ПОСЛЕ

            oldContacts[N].Firstname = newData.Firstname;
            oldContacts[N].Lastname = newData.Lastname;
            //oldContacts[N].Middlename = newData.Middlename;
            
            oldContacts.Sort();
            
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);//Сравниваем массив контактов ДО+новый (*) и массив после 
            foreach (ContactData contact in newContacts)
            {
                if (contact.ContactID == toBeModifyed.ContactID)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }

    }
}