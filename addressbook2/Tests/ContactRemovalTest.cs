using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            int N = 1;//ВВОДИМ САМИ Порядковый номер удаляемого контакта начиная с нуля!!!

            app.Contacts.ContactExist();
            List<ContactData> oldContacts = ContactData.GetAll();
            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[N];
            app.Contacts.RemoveContact(N);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            //List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(N);//

            Assert.AreEqual(oldContacts, newContacts); //Стандартный метод сравнения
                                                       //Equals(oldGroups, newGroups); //Метод созданный нами ( в GroupData )
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ContactID, toBeRemoved.ContactID);
            }
        }
        
    }
}
