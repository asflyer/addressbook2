using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allemail;
        private string contactDetails;
        //private string contactMainInfo;

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, /*string middlename, */string lastname)
        {
            Firstname = firstname;
            //Middlename = middlename;
            Lastname = lastname;

        }

        public ContactData()
        {
        }
          
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string ContactID { get; set; }
        public string Birthday { get; set; }
        public string Company { get; set; }
        public string Anniversary { get; set; }
        public string SecondaryHome { get; set; }
        public string FaxPhone { get; set; }
        public string HomePage { get; set; }
        public string Title { get; set; }
        public string AddressSecondary { get; set; }
        public string NotesSecondary { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allemail != null)
                {
                    return allemail;
                }
                else
                {
                    return (Cleanup(Email1) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }
            set
            {
                allemail = value;
            }
        }

        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return contactDetails;
                }
                else
                {
                    contactDetails = "";

                    if (Firstname != "")
                    {
                        contactDetails += Firstname;
                    }
                    else Firstname = null;

                    if (Middlename != "")
                    {
                        contactDetails += " " + Middlename;
                    }
                    else Middlename = null;

                    if (Lastname != "")
                    {
                        contactDetails += " " + Lastname;
                    }
                    else Lastname = null;

                    if (Nickname != "")
                    {
                        contactDetails += "\r\n" + Nickname;
                    }
                    else Nickname = null;

                    if (Title != "")
                    {
                        contactDetails += "\r\n" + Title;
                    }
                    else Title = null;
                    if (Company != "")
                    {
                        contactDetails += "\r\n" + Company;
                    }
                    else Company = null;
                    if (Address != null)
                    {
                        contactDetails += "\r\n" + Address;
                    }
                    
                    if (HomePhone != "")
                    {
                        contactDetails += "\r\n\r\n"+ "H: " + HomePhone ;
                    }
                    else HomePhone = null;

                    if (MobilePhone != "")
                    {
                        contactDetails += "\r\n" +"M: " + MobilePhone;
                    }
                    else MobilePhone = null;

                    if (WorkPhone != "")
                    {
                        contactDetails += "\r\n" +"W: " + WorkPhone ;
                    }
                    else WorkPhone = null;

                    if (FaxPhone != "")
                    {
                        contactDetails += "\r\n" + "F: " + FaxPhone;
                    }
                    else FaxPhone = null;
                    if (Email1 != null)
                    {
                        contactDetails += "\r\n\r\n" + Email1;
                    }
                    if (Email2 != null)
                    {
                        contactDetails += "\r\n" + Email2;
                    }
                    if (Email3 != null)
                    {
                        contactDetails += "\r\n" + Email3;
                    }
                    
                    if (HomePage != "")
                    {
                        contactDetails += "\r\n" + "Homepage:\r\n" + HomePage;
                    }
                    else HomePage = null;
                    if (Birthday != "")
                    {
                        contactDetails += "\r\n\r\n" + Birthday;
                    }
                    else Birthday = null;
                    if (Anniversary != "")
                    {
                        contactDetails += "\r\n"+ Anniversary;
                    }
                    else Anniversary = null;
                    if (AddressSecondary != "")
                    {
                        contactDetails += "\r\n\r\n" + AddressSecondary;
                    }
                    
                    if (SecondaryHome != "")
                    {
                        contactDetails += "\r\n\r\n" + "P: " + SecondaryHome;
                    }
                    else SecondaryHome = null;
                    if (NotesSecondary != "")
                    {
                        contactDetails += "\r\n\r\n" + NotesSecondary + "\r\n";
                    }
                    else NotesSecondary = null;
                    return contactDetails.Trim();
                }
            
            }
            set
            {
                contactDetails = value;
            }
        }

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[  -- ()]", "") + "\r\n";
            //то же самое - return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";

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
            /*if (Firstname == other.Firstname)
            {
                return Lastname == other.Lastname;
            }
            return Firstname == other.Firstname; */
            return (Firstname == other.Firstname) && (Lastname == other.Lastname) ;//Не уверен, что так можно
        }

        public override int GetHashCode()
        {
            //return 0;//Так будет всегда вызываться сразу метод Equals (если не ноль, тогда сначала сравниваются, хэшкоды, а если они одинаковые, то вызывается Equals)
            return Firstname.GetHashCode() + Lastname.GetHashCode() ;//Хэш коды вычисляются только по именам и фамилиям
        }
        
        public override string ToString()//Возвращает строковое представление объектов типа 
        {
            return ("firstname= " + Firstname + "\nlastname= "+ Lastname + "\nAddress= " + "\nMiddlename= " + Middlename + "\nNickname= " + Nickname
                + Address + "\nMobilePhone= " + MobilePhone + "\nWorkPhone= " + WorkPhone + "\nCompany= " + Company + "\nhomePhone= " + HomePhone +
                "\nEmail1= " + Email1 + "\nHomePage= " + HomePage + "\nNotesSecondary=" + NotesSecondary);
        }
       
        public int CompareTo(ContactData other) //GroupData other - объект с которым сравниваем текущий
        {//(вернёт 1, если текущий объект > other) (вернёт 0, если они равны) (вернёт -1, если текущий < other)

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if(Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }
    }
}