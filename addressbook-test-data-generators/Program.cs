using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.csv csv
    //тут 2 - кол-во строк, groups.csv - имя файла, csv - расширение
    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.xlsx excel
    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 3 groups.json json
    class Program
    {
        static void Main(string[] args)
        {
            

            int count = Convert.ToInt32(args[0]); //Кол-во генерируемых ТД
            string filename = args[1];
            string format = args[2];//было3

            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<count; i++)
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
           
            System.Console.Out.Write("Complete! File created!");
            //Файл генерируется в C:\Users\Александр
            

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

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {

            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));

        }

    }
}
