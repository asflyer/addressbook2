using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class ContactData
    {
        public string firstname;
        public string middlename;
        public string lastname;
        public string nickname = "1";
        public string company = "2";
        public string address = "2";
        public string telhome = "";
        public string telmobile = "";
        public string telwork = "";
        public string email = "";
        public string byear = "1999";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public ContactData(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;

        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
    }
}
