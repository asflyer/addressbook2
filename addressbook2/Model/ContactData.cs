﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class ContactData : IEquatable<ContactData>
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

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))//Если объект с которым сравниваем это null
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))//Если это один и тот же объект
            {
                return true;
            }
            return (Firstname == other.Firstname)&&(Lastname == other.Lastname);//Не уверен, что так можно
        }

        public int GetHashCode()
        {
            //return 0;//Так будет всегда вызываться сразу метод Equals (если не ноль, тогда сначала сравниваются, хэшкоды, а если они одинаковые, то вызывается Equals)
            return Firstname.GetHashCode() + Lastname.GetHashCode();//Хэш коды вычисляются только по именам и фамилиям
        }

    }
}
