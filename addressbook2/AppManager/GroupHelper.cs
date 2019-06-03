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

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupPage();

            List<GroupData> groups = new List<GroupData>();

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //Коллекция (группа, множество) элементов типа IwebElement
            foreach(IWebElement element in elements) //Для каждого элемента в коллекции
            {
                groups.Add(new GroupData(element.Text)); //Преобразуем объекты IWebElement в объекты типа GroupData
            }
            return groups;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;

        }

        public void GroupExist()
        {
            manager.Navigator.GoToGroupPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("a");
                Create(group);
            }
            return;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
           
        }

        public GroupHelper ReturnToGroupPage()
        {
            //Переходим на страничку group page
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.Name("new"));
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            //Кликаем submit
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm (GroupData group)
        {
            //Заполняем форму

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }



        public GroupHelper InitGroupCreation()
        {
            //Кликаем new для создания новой группы
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();

            return this;
        }


    }
}
