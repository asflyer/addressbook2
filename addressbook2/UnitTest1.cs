using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSqare()
        {
            Square s1 = new Square(5); //создали переменную и присвоили ей значение равное ссылке на объект класса Square
            Square s2 = new Square(10);
            Square s3 = s1;



            Assert.AreEqual(s1.Size, 5); //Получаем размер квадрата и проверяем, что он равен 5
            Assert.AreEqual(s2.Size, 10); //Создаем еще объект того же класса
            Assert.AreEqual(s3.Size, 5);


            s3.Size = 15;
            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;


        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(5); //создали переменную и присвоили ей значение равное ссылке на объект класса Square
            Circle s2 = new Circle(10);
            Circle s3 = s1;



            Assert.AreEqual(s1.Radius, 5); //Получаем размер квадрата и проверяем, что он равен 5
            Assert.AreEqual(s2.Radius, 10); //Создаем еще объект того же класса
            Assert.AreEqual(s3.Radius, 5);


            s3.Radius = 15;
            Assert.AreEqual(s1.Radius, 15);

            s2.Colored = true;
        }


    }
    
}
