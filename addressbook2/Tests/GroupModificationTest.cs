using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace web_addressbook_test
{
    [TestFixture]

    public class GroupModificationTest : AuthTestBase
    {
        [Test]

        public void GroupModificationTestCase()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null; 
            newData.Footer = "xxx";
            int N = 1;//Порядковый номер изменяемой группы
            
            if (app.Groups.GroupNotExist())
            {
                GroupData group = new GroupData("a");
                app.Groups.Create(group);
                N = 1;
            }

            app.Groups.Modify(N, newData);
   
        }

    }
}
