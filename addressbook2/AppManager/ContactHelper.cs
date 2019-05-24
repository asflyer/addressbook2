using System;
using System.Text.RegularExpressions;
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
    public class ContactHelper : HelperBase

    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click(); 
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" +index+ "]")).Click();
            return this;
        }

        internal ContactHelper RemoveContact(int v)
        {
            SelectContact(v + 1); //для того, чтобы сошелся номер
            DeleteContact();
            manager.Navigator.OpenHomePage(); 
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper AddContact(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        private ContactHelper SubmitContactCreation()
        {
            //Подтверждаем создание
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private ContactHelper FillContactForm(ContactData contact)
        {
            //Заполняем поля
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("Nickname"), contact.Nickname);


            return this;
        }

        public ContactHelper InitContactCreation()
        {
            //Кликаем новый контакт
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[ " + index + "]/td/input")).Click();//тут tr4 = 3 строчка (получил рекордером)
            return this;
        }

    }
}