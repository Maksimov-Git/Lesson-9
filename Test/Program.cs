using System;

namespace Test
{
    class Program
    {
        public delegate void Mydel();


        public delegate int Function(int a);

        static void Main(string[] args)
        {

            #region инициализация

            //создание экземпляра делегата и его инициализация анонимным методом через конструктор 
            Mydel ex1 = new Mydel(delegate { Console.WriteLine("Hello"); });

            //создание экземпляра делегата и его инициализация анонимным методом через 
            // предположение делегата

            Mydel ex2 = delegate { Console.WriteLine("Hello"); };

            //присвеоение метода из другого класса

           // Mydel ex3 = Class1.Method();



            #endregion


            #region Лямбда

            Function ex3;

            ex3 = delegate (int x)
            {

                for (int i = 0; i < 10; i++)
                {
                    x++;
                }

                return x; 
            };   //лимбда метод

            ex3 += (x) => { return x * 3; };               //лямбда-оператор

            ex3 += x => x * 2;                           //лямбда-выражение

            #endregion
            Console.WriteLine(ex3(1));
            Console.WriteLine(ex3.Invoke(1));
            


        }
    }
}
