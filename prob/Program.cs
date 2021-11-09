using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prob
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Mass()
            {
                int a;
                Random random = new Random();
                Console.WriteLine("Введите размер массива:");
                bool result = int.TryParse(Console.ReadLine(), out a);
                if (result)
                {
                    Console.WriteLine($"Размер массива {a}");
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите число");
                }
                int[] mas = new int[a];
                for (int i = 0; i < a; i++)
                {
                    mas[i] = random.Next(0, 100);
                }
                return mas;
            }

            void Max()
            {
                int[] p = Mass();
                int max = p.Max();
                Console.WriteLine($"Максимальное значение в массиве: {max}");
            }
            //int[] p = Mass();
            //for (int i = 0; i < p.Length; i++)
            //{
            //    {
            //        Console.Write(p[i] + " ");
            //    }
            //    Console.WriteLine();
            //}
            Max();
            Console.ReadKey();
        }
    }
}
