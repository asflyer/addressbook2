﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace web_addressbook_test
{
    
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            app.Contacts.RemoveContact(3);//указывается порядковый номер записи в таблице на странице home

        }
        
    }
}
