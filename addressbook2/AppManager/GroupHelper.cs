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
    public class GroupHelper : HelperBase
    {
        //private IWebDriver driver;

        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }

        public void ReturnToGroupPage()
        {
            //Переходим на страничку group page
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void SubmitGroupCreation()
        {
            //Кликаем submit
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            //Заполняем форму
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void InitGroupCreation()
        {
            //Кликаем new для создания новой группы
            driver.FindElement(By.Name("new")).Click();
        }


        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

    }
}
