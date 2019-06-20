using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
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

        string birthday;
        string anniversary;

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allemail = cells[4].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allemail

            };


        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContactToAddToGroup(contact.ContactID);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            //WebDriver периодически проверяет загрузился ли элемент успешного завершения операции
        }

        public void SelectContactToAddToGroup(string ContactID)
        {
            driver.FindElement(By.Id(ContactID)).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            //SelectElement = выпадающее меню
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInformationFromEditFormAll(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string faxPhone = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            if (byear != "0" && byear !=null && byear !="")
            {
                int y = Int32.Parse(byear);
                string bdate = bday + bmonth + byear;

                DateTime ConvertToDateTime(string value)
                {
                    DateTime convertedDate;
                    convertedDate = Convert.ToDateTime(value);
                    Console.WriteLine("'{0}' converts to {1} {2} time.", value, convertedDate, convertedDate.Kind.ToString());
                    return convertedDate;
                }

                DateTime date = ConvertToDateTime(bdate);


                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - y;
                if (date > nowDate.AddYears(-age)) age--;
                birthday = ("Birthday " + bday + ". " + bmonth + " " + byear + " (" + age + ")");
            }
            /*
            else
            {
                birthday = "";
            }
            */
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            //string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string amonth = driver.FindElement(By.XPath("/html/body/div/div[4]/form[1]/select[4]/option[1]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            if (ayear != "")
            {
                anniversary = "Anniversary " + aday + ". " + amonth + " " + ayear;
            }

            string addressSecondary = driver.FindElement(By.Name("address2")).GetAttribute("value"); //Вот тут может быть неправильно. Обратить внимание
            string secondaryHome = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notesSecondary = driver.FindElement(By.Name("notes")).GetAttribute("value"); //Вот тут может быть неправильно. Обратить внимание


            return new ContactData(firstname, lastname)
            {
                Middlename = middlename,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = faxPhone,
                Email1 = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = homePage,
                Birthday = birthday,
                Anniversary = anniversary,
                AddressSecondary = addressSecondary,
                SecondaryHome = secondaryHome,
                NotesSecondary = notesSecondary
            };
        }

        public ContactData GetContactDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenContactDetailsPage(index);

            //string contactMainInfo = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text;//firstname middlename lastname

            //nickname, Company, Address, AddressSecondary, NotesSecondary

            string contactDetails = driver.FindElement(By.Id("content")).Text.Trim();

            //Эта строчка не получается!!!!! Ничего не находит!
            //string contactDetails = driver.FindElement(By.Id("content")).FindElements(By.TagName("br")).Text;//все остальное
            //Нужно проверить, что br != null

            /*
            string title = driver.FindElement(By.CssSelector("div.content")).FindElement(By.TagName("i")).Text;
            string homePhone = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='H: ']")).Text;
            string mobilePhone = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='M: ']")).Text;
            string workPhone = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='W: ']")).Text;
            string faxPhone = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='F: ']")).Text;
            string secondaryHome = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='P: ']")).Text;
            string homePage = driver.FindElement(By.CssSelector("div.content")).FindElement(By.TagName("label")).Text;
            string email = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='E-mail:']")).Text;
            string email2 = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='E-mail2:']")).Text;
            string email3 = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='E-mail3:']")).Text;
            string birthday = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='Birthday ']")).Text;
            birthday.Substring(0, birthday.Length - 5);
            string anniversary = driver.FindElement(By.CssSelector("div.content")).FindElement(By.XPath(".//*[.='Anniversary ']")).Text;
            */

            return new ContactData()
            {
                //ContactMainInfo = contactMainInfo,
                ContactDetails = contactDetails
            };
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(contact.ContactID);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public void ContactExist()
        {
            manager.Navigator.OpenHomePage();
            if (!IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new ContactData("");
                AddContact(contact);
            }
            return;

        }

        public ContactHelper RemoveContact(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(v); 
            DeleteContact();
            return this;
        }

        public ContactHelper RemoveContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContactToAddToGroup(contact.ContactID);
            //SelectContact(v);
            DeleteContact();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));//ожидание сообщения об успешном удалении контакта
            contactCash = null;
            return this;
        }

        public ContactHelper AddContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
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
            contactCash = null;
            return this;
        }

        private ContactHelper FillContactForm(ContactData contact)
        {
            //Заполняем поля
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);


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
            driver.FindElement(By.XPath("//tr[ " + (index+2) + "]/td/input")).Click();//тут tr4 = 3 строчка (Xpath привет) и Еще +1 потому что начинаем нумерацию с нуля)
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            driver.FindElement(By.CssSelector("div.msgbox"));//ожидание сообщения об успешном успехе ))
            contactCash = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(string ID)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + ID + "']/../..)")).FindElement(By.XPath("(.//img[@alt='Edit'])")).Click();
            //УРА! ПОБЕДА!
            return this;
        }

        public ContactHelper OpenContactDetailsPage(int index)
        {
            
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public int GetContactCount()
        {
            manager.Navigator.OpenHomePage();//Пришлось добавить иначе Тест начинает считать контакты на странице "Record successful deleted"
            return driver.FindElements(By.CssSelector("[ name = 'entry' ]")).Count;
        }

        private List<ContactData> contactCash = null;
        
        public List<ContactData> GetContactList()
        {
            /*
            Алгоритм получения списка контактов должен быть такой:
            1.Получаем список всех строк таблицы контактов(это элементы с именем entry)
            2.В цикле пробегаемся по каждой строке, и с помощью element.FindElements получаем список ячеек(это элементы с тегом td)
            3.Берём текст из ячеек с нужным нам индексом(cells[1].Text)
            */
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                  
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[ name = 'entry' ]")); //ищем элемент с аттрибутом name = entry (привет CSS селекторы)

                foreach (IWebElement element in elements) //Для каждого элемента в коллекции
                {
                    // так раньше работало
                    ContactData contact = new ContactData(element.FindElement(By.XPath(".//td[3]")).Text,/* "" ,*/ element.FindElement(By.XPath(".//td[2]")).Text);

                    
                    contact.ContactID = element.FindElement(By.TagName("input")).GetAttribute("value");
                    contactCash.Add(contact);
                    //

                    //так ерунда
                    /*
                    contactCash.Add(new ContactData(element.Text)
                    {
                        ContactID = element.FindElement(By.TagName("input")).GetAttribute("value")
                        element.FindElement(By.XPath(".//td[3]")),
                        //Middlename = "",
                        Lastname = element.FindElement(By.XPath(".//td[2]"))
                    });

//                    (element.FindElement(By.XPath(".//td[3]")).Text, "", element.FindElement(By.XPath(".//td[2]")).Text)
                    /*groupCash.Add(new GroupData(element.Text)
                    {
                        ID = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                    */
                    
                }
                
            }
            return new List<ContactData>(contactCash);

        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

    }
}