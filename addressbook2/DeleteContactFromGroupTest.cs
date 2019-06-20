using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace web_addressbook_test
{

    public class DeleteContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTestCase() //Быстрый тест - проверка удаления в БД
        {
            GroupData group = GroupData.GetAll().Find(x => x.Name.Contains("zzz"));//Сами задаем имя группы из корторой удаляем
            //app.Contacts.SelectGroupDropdown(group.Name);
                        
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов в группе
            ContactData contact = oldList[0]; //Берем первый из контактов в группе
            
            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts(); //Запоминаем старый список контактов

            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }

        [Test]
        public void LongDeleteContactFromGroupTestCase() //В этом тесте добавил проверку в GUI
        {
            GroupData group = GroupData.GetAll().Find(x => x.Name.Contains("zzz"));

            List<ContactData> oldContacts = app.Contacts.GetContactInGroupList(group);
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов в группе
            ContactData contact = oldList[0]; //Берем первый из контактов в группе
                    
            app.Contacts.DeleteContactFromGroup(contact, group);
            List<ContactData> newContacts = app.Contacts.GetContactInGroupList(group);
            List<ContactData> newList = group.GetContacts(); //Запоминаем старый список контактов
            
            //Проверка в БД
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

            //Проверка в GUI
            oldContacts.Remove(contact);
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        
    }
}
