using System;
using NUnit.Framework;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            int N = 0;//ВВОДИМ САМИ Порядковый номер удаляемого контакта начиная с нуля!!!

            app.Contacts.ContactExist();


            app.Contacts.RemoveContact(N);



        }
        
    }
}
