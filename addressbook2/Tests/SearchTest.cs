using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace web_addressbook_test
{
    public class SearchTest : AuthTestBase
    {
        [Test]
         public void SearchTestCase()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }



    }
}
