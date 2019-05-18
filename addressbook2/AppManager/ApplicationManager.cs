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
    public class ApplicationManager
    {
        protected IWebDriver driver;// Protected означает что "оно все еще внутреннее, но наследники тоже получают доступ"
        protected string baseURL;


        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;

        

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            


            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
        }

        public LoginHelper Auth
        {
           get
           {
               return loginHelper;
            }
        }
        
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
                 
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
         

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }






    }
}
