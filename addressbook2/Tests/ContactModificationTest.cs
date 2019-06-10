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
            int N = 1;//порядковый номер записи на странице home  начиная с нуля!!!

            app.Contacts.ContactExist();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeModifyed = oldContacts[N];
            app.Contacts.Modify(N, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList(); //Считываем список контактов ПОСЛЕ

            oldContacts[N].Firstname = newData.Firstname;
            oldContacts[N].Lastname = newData.Lastname;
            //oldContacts[N].Middlename = newData.Middlename;
            oldContacts.Sort();
            //oldContacts.Sort((emp1, emp2) => emp1.lastname.CompareTo(emp2.lastname));
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