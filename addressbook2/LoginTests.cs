using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace web_addressbook_test
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentails()
        {
            //Подготовка
            app.Auth.Logout();//На случай того, если после прошлого теста остались в системе

            //Действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //Проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentails()
        {
            //Подготовка
            app.Auth.Logout();//На случай того, если после прошлого теста остались в системе

            //Действие
            AccountData account = new AccountData("admin", "sdfghjkl");
            app.Auth.Login(account);

            //Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
