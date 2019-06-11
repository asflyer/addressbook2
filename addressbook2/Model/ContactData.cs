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
        public string nickname = "1";
        public string company = "2";
        public string address = "2";
        public string telhome = "";
        public string telmobile = "";
        public string telwork = "";
        public string email = "";
        public string byear = "1999";
        private string allPhones;
        private string allemail;

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


        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[  -- ()]", "") + "\r\n";
            //return Regex.Replace(phone, @"\W", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";

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
            return (" firstname=" + Firstname + " lastname="+ Lastname);
        }

        /*
        public int CompareTo(ContactData other) //GroupData other - объект с которым сравниваем текущий
        {//(вернёт 1, если текущий объект > other) (вернёт 0, если они равны) (вернёт -1, если текущий < other)
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname) & Lastname.CompareTo(other.Lastname) ;

        }
        */
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
