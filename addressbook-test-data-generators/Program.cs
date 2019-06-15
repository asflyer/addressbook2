using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using web_addressbook_test;


namespace addressbook_test_data_generators
{
    //Запускаемый exeшник в D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe
    //Для запуска копировать в cmd

    //D:\c#projects\addressbook2\addressbook2\addressbook-test-data-generators\bin\Debug\addressbook-test-data-generators.exe 2 groups.csv
    //тут 2 - кол-во строк, groups.csv - имя файла
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //Кол-во генерируемых ТД
            StreamWriter writer = new StreamWriter(args[1]);//Записываем в файл с именем args[1]
            for (int i=0; i<count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    TestBase.GenerateRandomString(100),
                    TestBase.GenerateRandomString(100),
                    TestBase.GenerateRandomString(100)));
            }
            writer.Close();
            //System.Console.Out.Write("Hello, World");

            //Файл генерируется в C:\Users\Александр
        }
    }
}
