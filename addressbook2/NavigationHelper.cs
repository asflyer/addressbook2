using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace web_addressbook_test
{
    public class NavigationHelper : HelperBase
    {
        //private IWebDriver driver;
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
           // this.driver = driver;
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            //Открываем домашнюю страницу 
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupPage()
        {
            //Переходим на groups
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
