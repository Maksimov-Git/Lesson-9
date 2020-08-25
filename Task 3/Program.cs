using System;
using System.Threading;

namespace ArrayOfDelegates
{
    class Program
    {
        //сюда мы запишем метод рандом
        delegate int Randoms();

        //делегат считает среднее арифм
        delegate double MyDel(Randoms[] a);

        static public int GetRandom()
        {
            Random rnd = new Random();
            return rnd.Next(100);
        }

        static void Main()
        {
            Console.WriteLine("Введите число элементов массива:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(new string('-', 50));

            var array = new Randoms[n];
            //инициализируем все делегаты из массива
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = () => new Randoms(GetRandom).Invoke();
            }
            
            
            //инициализируем делает, который будет считать значения массива делегатов
            MyDel d = delegate(Randoms[] c)
                                            {
                                                double sr = 0;
                                                for (int i = 0; i < c.Length; i++)
                                                {
                                                    sr += c[i].Invoke();
                                                }
                                                return sr / array.Length;
                                            };

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].Invoke() + " ");
            }

            Console.WriteLine("\nСреднее арифметическое элементов {0:##.###}", d(array));

            //Delay
            Console.ReadKey();
        }
    }
}
