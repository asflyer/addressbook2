using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace web_addressbook_test
{
    public class ApplicationManager : TestBase
    {
        protected IWebDriver driver;// Protected означает что "оно все еще внутреннее, но наследники тоже получают доступ"
        protected string baseURL;


        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();//устанавливает соответствие между текущим потоком и объектом типа ApplicationManager




        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            
            
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationManager() //Деструктор (тильдаКласс)
        {
            try
            {
                driver.Quit();//Остановка браузера
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance() //static - глобальный. Можно будет обращаться как к ApplicationManager.GetInstance()
        {
            if (! app.IsValueCreated) //Если для текущего потока внутри этого хранилища ничего не создано, то создаем
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
                
            }
            return app.Value;
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

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }





    }
}
