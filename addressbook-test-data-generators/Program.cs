using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using web_addressbook_test;
using System.Xml;
using System.Xml.Serialization;


namespace addressbook_test_data_generators
{
    //Запускаемый exeшник в D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe
    //Для запуска копировать в cmd

    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.csv
    //тут 2 - кол-во строк, groups.csv - имя файла

    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.xml xml
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //Кол-во генерируемых ТД
            StreamWriter writer = new StreamWriter(args[1]);//Записываем в файл с именем args[1]

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
           
            //System.Console.Out.Write("Hello, World");
            //Файл генерируется в C:\Users\Александр
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();

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

    }
}
