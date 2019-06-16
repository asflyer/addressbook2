using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using web_addressbook_test;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    //Запускаемый exeшник в D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe
    //Для запуска копировать в cmd

    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.xlsx excel
    //тут 2 - кол-во строк, groups.csv - имя файла, csv - расширение
    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 contacts.xlsx excel
    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 3 contacts.xml xml
    //Файл генерируется в C:\Users\Александр
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //Кол-во генерируемых ТД
            string filename = args[1];
            string format = args[2];//было3 в лекции

            if (filename.Contains("contacts"))
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Middlename = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        FaxPhone = TestBase.GenerateRandomString(10),
                        Email1 = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        HomePage = TestBase.GenerateRandomString(10),
                        AddressSecondary = TestBase.GenerateRandomString(10),
                        SecondaryHome = TestBase.GenerateRandomString(10),
                        NotesSecondary = TestBase.GenerateRandomString(10),
                    });

                }

                if (format == "excel")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);//Записываем в файл с именем args[1]
                    if (format == "csv")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();

                   
                }
                
                System.Console.Out.Write("Complete! ContactData file with name " + filename + " created!");
            }
            else if (filename.Contains("groups"))
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });

                }

                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);//Записываем в файл с именем args[1]
                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                  
                }
                System.Console.Out.Write("Complete! GroupData file with name " + filename + " created!");
            }
            else
            {
                System.Console.Out.Write("Must use the following format - .exe <quantity> <groups/contacts>.<json/csv/xlsx> <json/csv/xlsx>");
            }
            
        }
        

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application(); //Вот этот код запускает Excel через Com интерфейс
            app.Visible = true; //Делаем окно видимым
            //Вот этот код запускает Excel через Com интерфейс

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;

            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath); //Передаем полный путь к файлу, чтобы Excel сохранил туда куда нужно
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application(); //Вот этот код запускает Excel через Com интерфейс
            app.Visible = true; //Делаем окно видимым
            //Вот этот код запускает Excel через Com интерфейс

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Middlename;
                sheet.Cells[row, 3] = contact.Lastname;
                sheet.Cells[row, 4] = contact.Nickname;
                sheet.Cells[row, 5] = contact.Title;
                sheet.Cells[row, 6] = contact.Company;
                sheet.Cells[row, 7] = contact.Address;
                sheet.Cells[row, 8] = contact.HomePhone;
                sheet.Cells[row, 9] = contact.MobilePhone;
                sheet.Cells[row, 10] = contact.WorkPhone;
                sheet.Cells[row, 11] = contact.FaxPhone;
                sheet.Cells[row, 12] = contact.Email1;
                sheet.Cells[row, 13] = contact.Email2;
                sheet.Cells[row, 14] = contact.Email3;
                sheet.Cells[row, 15] = contact.HomePage;
                sheet.Cells[row, 16] = contact.AddressSecondary;
                sheet.Cells[row, 17] = contact.SecondaryHome;
                sheet.Cells[row, 18] = contact.NotesSecondary;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath); //Передаем полный путь к файлу, чтобы Excel сохранил туда куда нужно
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }

        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16},${17}",
                    contact.Firstname,
                    contact.Middlename,
                    contact.Lastname,
                    contact.Nickname,
                    contact.Title,
                    contact.Company,
                    contact.Address,
                    contact.HomePhone,
                    contact.MobilePhone,
                    contact.WorkPhone,
                    contact.FaxPhone,
                    contact.Email1,
                    contact.Email2,
                    contact.Email3,
                    contact.HomePage,
                    contact.AddressSecondary,
                    contact.SecondaryHome,
                    contact.NotesSecondary
                    ));

            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
