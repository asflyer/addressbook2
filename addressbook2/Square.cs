using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook2
{
    class Square : Figure
    {
        private int size; // Этот size - ПОЛЕ!

        public Square (int size) //CСоздаем Конструктор, который называется так же, как Класс
        {
            this.size = size; //Этот size - ПЕРЕМЕННАЯ
            //В поле присваиваем значение, которое передано в качестве параметра
            //this - означает, что мы в поле текущего объекта помещаем значение переданное в качестве параметра
        }
        
        public int Size //Property (свойства)
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }


        /*
        public int GetSize() //Получаем размер квадрата
        {
            return size;
        }

        public void SetSize( int size)
        {
            this.size = size;
        }
        */
        //Методы GetSize и SetSize заменили Property
    }
}
