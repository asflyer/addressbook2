using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace web_addressbook_test
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
            //this.manager = manager;
            //теперь тут пусто
        }

        public void Login(AccountData account) //Входной параметр метода Login - объект account класса AccountData 
        {
            //Авторизация 
            //driver.FindElement(By.Name("user")).Click();
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            //Logout
            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
