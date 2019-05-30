using NUnit.Framework;
using OpenQA.Selenium;

namespace web_addressbook_test
{
   
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            ContactData newData = new ContactData("454456"); //newData.Firstname
            newData.Middlename = "454456";
            newData.Lastname = "454456";
            int N = 1;//порядковый номер записи на странице home

            if (app.Contacts.ContactExist())
            {
                app.Contacts.Modify(N, newData); 
            }
            else
            {
                ContactData contact = new ContactData("");
                app.Contacts.AddContact(contact);
                app.Contacts.Modify(1, newData); 
            }
            
        }

    }
}
