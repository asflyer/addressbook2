using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace web_addressbook_test
{
    public class TestBase
    {
        public ApplicationManager app;

        [SetUp]

        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            
        }

    }
}
