using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace web_addressbook_test
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase

    {
        //Ниже Генерируем 5 наборов ТД - то есть 5 тестов. 
        /* Для их запуска в консоли
        nunit3-console D:\c#projects\addressbook2\addressbook2\addressbook2.sln --test=web_addressbook_test.GroupCreationTests
        */
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30)) //тут 30 - максимальное количество символов в генерируемой строке
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),

                });
            }
            return groups;
        }

        //Ниже Создаем метод чтения из файла. 
        //Файл текстовый с именем groups.csv - наборы GroupData - строчки. Разделены Имя, хидер и футер - запятыми
        //Файл читается из папки D:\c#projects\addressbook2\addressbook2

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts [1],
                    Footer = parts [2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) //Явно указываем какого типа возвращаемый объект
                new XmlSerializer(typeof(List<GroupData>))//Читаем данные типа GroupData
                .Deserialize(new StreamReader(TestContext.CurrentContext.TestDirectory + @"\groups.xml"));//Из файла с именем groups.xml

        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(TestContext.CurrentContext.TestDirectory + @"\groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(TestContext.CurrentContext.TestDirectory, @"groups.xlsx"));//Открываем файл
            //Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));//Открываем файл
            Excel.Worksheet sheet = wb.ActiveSheet;//При открытии сразу попадаем на активную страницу (лист)
            Excel.Range range = sheet.UsedRange;//Находим прямоугольник, который содержит какие-то данные
            for (int i=1; i<=range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i,1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });

            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        //Для тестов из генерации так [Test, TestCaseSource("RandomGroupDataProvider")] +
        //Для тестов из файла csv так [Test, TestCaseSource("GroupDataFromCsvFile")] +
        //Для тестов из файла json так [Test, TestCaseSource("GroupDataFromJsonFile")] +
        //Для тестов из файла xml так [Test, TestCaseSource("GroupDataFromXmlFile")] + 
        //Для тестов из файла exlel так [Test, TestCaseSource("GroupDataFromExcelFile")]
        //меняем тут название, копируем файл в наш проект, 

        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {
            /*Чтобы задавать данные для создания тут нужно подредактировать выше GroupCreationTest() - оставить пустым
             * GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";*/

            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);

            
            Assert.AreEqual(oldGroups.Count +1 , app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine("UI");
            System.Console.Out.WriteLine(end.Subtract(start));//Вычитаем из метки которую сделали вконце метку вначале

            DateTime start1 = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();

            DateTime end1 = DateTime.Now;

            System.Console.Out.WriteLine("DB");
            System.Console.Out.WriteLine(end1.Subtract(start1));//Вычитаем из метки которую сделали вконце метку вначале

        }

        /* Вместо этого пока используем тесты с рандомными входными данными! 
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            //Thread.Sleep(100); //Костыль - иначе падает при массовом запуске
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        */

        /*
        [Test]//Тест для того, чтобы проверить, что наши проверки работают
               
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a")//группа с одинарной кавычкой не создается (багуля) - new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };
            //Thread.Sleep(100); //Костыль - иначе падает при массовом запуске
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count +1 , app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        */
    }
}