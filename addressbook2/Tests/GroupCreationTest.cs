using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace web_addressbook_test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    {
        //Генерируем 5 наборов ТД - то есть 5 тестов. 

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

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            /*GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "ccc";
            */
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            
            Assert.AreEqual(oldGroups.Count +1 , app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

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