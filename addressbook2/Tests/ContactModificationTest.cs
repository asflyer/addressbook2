using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace web_addressbook_test
{
   
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {

            ContactData newData = new ContactData ("454456"); //newData.Firstname
            newData.Middlename = "454456";
            newData.Lastname = "454456";
            
            app.Contacts.Modify(1, newData); //порядковый номер записи на странице home

        }

    }
}
