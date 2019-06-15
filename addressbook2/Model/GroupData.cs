using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //Класс можно сравнивать с другими объектами типа GroupData
    {
        public GroupData()
        {
        }
        public GroupData(string name)
        {
            Name = name; //Для свойства с автомат реализацией - присваивание свойства
            //this.name = name;// Для записи через геттер/сеттер - присваивание поля
        }
        //для обратной совместимости вносим новый конструктор с тремя параметрами
        public GroupData (string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public string Name { get; set; } //Свойство с автоматической реализацией (то же самое, что и запись через геттер и сеттер ниже)
        /*public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }*/
        public string Header { get; set; }
        
        public string Footer { get; set; }

        public string ID { get; set; }

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

        public override int GetHashCode()
        {
            //return 0;//Так будет всегда вызываться сразу метод Equals (если не ноль, тогда сначала сравниваются, хэшкоды, а если они одинаковые, то вызывается Equals)
            return Name.GetHashCode();//Хэш коды вычисляются только по именам
            //override - переопределяет стандартный метод
        }

        public override string ToString()//Возвращает строковое представление объектов типа GroupData
        {
            return "name= " + Name + "\nheader= " + Header + "\nfoorer= " ;
        }

        public int CompareTo(GroupData other) //GroupData other - объект с которым сравниваем текущий
        {//(вернёт 1, если текущий объект > other) (вернёт 0, если они равны) (вернёт -1, если текущий < other)

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
