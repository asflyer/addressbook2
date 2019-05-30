using System;
using NUnit.Framework;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            int N = 1;//Порядковый номер удаляемого контакта

            if (app.Contacts.ContactExist())
            {
                app.Contacts.RemoveContact(N);
            }
            else
            {
                ContactData contact = new ContactData("");
                app.Contacts.AddContact(contact);
                app.Contacts.RemoveContact(1);
            }

            

        }
        
    }
}
