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
            int N = 0;//ВВОДИМ САМИ Порядковый номер удаляемого контакта начиная с нуля!!!

            app.Contacts.ContactExist();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveContact(N);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(N);//

            Assert.AreEqual(oldContacts, newContacts); //Стандартный метод сравнения
            //Equals(oldGroups, newGroups); //Метод созданный нами ( в GroupData )

        }
        
    }
}
