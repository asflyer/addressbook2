﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        }

        public void Login(AccountData account) //Входной параметр метода Login - объект account класса AccountData 
        {
            if (IsLoggedIn())//Проверяем авторизовны ли мы
            {
                if(IsLoggedIn(account))//Если авторизованы под учетной записью account, то ничего делать не нужно.
                {
                    return; //завершаем метод Login
                }
                driver.FindElement(By.LinkText("Logout")).Click();//заменил LogOut кликом, чтобы было меньше цикличности
                //Logout();//Если авторизованы под другой учеткой делаем логаут

            } //Если не авторизованы (или уже сделали логаут), то теперь авторизуемся
           
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUderName() == account.Username;
                
        }

        private string GetLoggetUderName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2); //отрезаем первый и последний символы (потому что начинается с нуля, а длина меньше на этот ноль и последний символ
            //Потому что FindElement(By.TagName("b")) возвращает "(admin)"
            // == System.String.Format("(${0})", account.Username);
            //Text == "(" + account.Username + ")" можно записать как Text == System.String.Format("(${0})", account.Username);
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                
                driver.FindElement(By.Name("user"));
            }
            
        }

    }
}
