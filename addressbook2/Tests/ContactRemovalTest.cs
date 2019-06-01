using System;
using NUnit.Framework;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            int N = 1;//ВВОДИМ САМИ Порядковый номер удаляемого контакта

            if (app.Contacts.ContactNotExist())
            {
                ContactData contact = new ContactData("");
                app.Contacts.AddContact(contact);
                N = 1;
            }

            app.Contacts.RemoveContact(N);



        }
        
    }
}
