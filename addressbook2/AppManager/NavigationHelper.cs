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

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
           // this.driver = driver;
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if(driver.Url == baseURL)
            {
                return;
            }
            //Открываем домашнюю страницу 
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupPage()//Переходим на groups
        {
            if (driver.Url == baseURL + "/group.php" //Проверяем, что мы на странице с таким адресом
                && IsElementPresent(By.Name("new"))) //И что там есть кнопка new (то есть мейн страница Групп)
                {
                    return;
                }
                 
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
