using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("Addressbook") { }
        
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }

    }
}
