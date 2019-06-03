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
            int N = 1;//порядковый номер записи на странице home  начиная с нуля!!!

            app.Contacts.ContactExist();

 
            app.Contacts.Modify(N, newData);


            
        }

    }
}
