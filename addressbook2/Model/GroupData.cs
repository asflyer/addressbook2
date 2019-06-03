using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class GroupData : IEquatable<GroupData> //Класс можно сравнивать с другими объектами типа GroupData
    {
        public string name;
        private string header; // = "";

        public GroupData(string name)
        {
            this.name = name;
        }
        //для обратной совместимости вносим новый конструктор с тремя параметрами
        public GroupData (string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string footer = "";
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        public bool Equals(GroupData other)
        {
            if(object.ReferenceEquals(other, null))//Если объект с которым сравниваем это null
            {
                return false;
            }
            if(object.ReferenceEquals(this,other))//Если это один и тот же объект
            {
                return true;
            }
            return Name == other.Name;//Сравниваем только имена, потому что только они отображаются и нам этого достаточно
        }

        public int GetHashCode()
        {
            //return 0;//Так будет всегда вызываться сразу метод Equals (если не ноль, тогда сначала сравниваются, хэшкоды, а если они одинаковые, то вызывается Equals)
            return Name.GetHashCode();//Хэш коды вычисляются только по именам
        }
    }
}
