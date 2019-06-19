using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace web_addressbook_test
{
    

    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {

            GroupData group = GroupData.GetAll()[0];//Предполагаем, что нашего контакта нет в группе с индектом 0
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            //Из всего списка контактов убираем те, которые входят в данную группу и берем первый из оставшихся

            //actions
            app.Contacts.AddContactToGroup(contact, group);



            List<ContactData> newList = group.GetContacts(); //Запоминаем старый список контактов

            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);



        }


    }
}
