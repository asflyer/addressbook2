﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace web_addressbook_test
{
    [TestFixture]

    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void ContactInformationTestCase()
        {
            int N = 0;
            //номер контакта для проверки

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(N);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(N);


            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }


        [Test]
        public void ContactInformationDetailsCase()
        {
            int N = 0;
            //номер контакта для проверки

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(N);
            ContactData fromDetails = app.Contacts.GetContactDetails(N);


            //verification

            Assert.AreEqual(fromTable, fromDetails);
            Assert.AreEqual(fromTable.Address, fromDetails.Address);
            Assert.AreEqual(fromTable.AllPhones, fromDetails.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromDetails.AllEmail);
        }

    }
}
