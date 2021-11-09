using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW22
{
    class Program
    {
        /*Сформировать массив случайных целых чисел(размер задается пользователем). 
        Вычислить сумму чисел массива и максимальное число в массиве. 
        Реализовать решение  задачи с  использованием механизма  задач продолжения.*/
        //static int[] mas;
        //static int a;
        static int[] Mass ()
        {
            //int a;
            Random random = new Random();
            Console.WriteLine("Введите размер массива:");
            int a = int.Parse(Console.ReadLine());
            //bool result = int.TryParse(Console.ReadLine(), out a);
            //if (result)
            //{
            //    Console.WriteLine($"Размер массива {a}");
            //}
            //else
            //{
            //    Console.WriteLine("Ошибка ввода. Введите число");
            //}
            int[] mas = new int[a];
            for (int i = 0; i < a; i++)
            {
                mas[i] = random.Next(0, 100);
            }
            return mas;
        }
        static void Sum(Task task)
        {
            //int[] s = (int[])m;
            int[] p = Mass();
            int sum = 0;
            foreach (int n in p)
            {
                sum=sum+n;
            }
            Console.WriteLine($"Сумма чисел в массиве равна {sum}");
        }
        static void Max(Task task3)
        {
            int[] p = Mass();
            int max = p.Max();
            Console.WriteLine($"Максимальное значение в массиве: {max}");
        }
        static void Main(string[] args)
        {
            Func<int[]> func = new Func<int[]>(Mass);
            Task < int[] > task1= new Task<int[]>(func);


            Action<Task> action1 = new Action<Task>(Sum);
            Task task2 = task1.ContinueWith(action1);

            //Action<Task> action1 = new Action<Task, object>(Sum);
            //Task task2 = task1.ContinueWith(action1, object);

            Action<Task> action2 = new Action<Task>(Max);
            Task task3 = task2.ContinueWith(action2);

            task1.Start();
            task1.Wait();
            task2.Wait();
            task3.Wait();
            Console.ReadKey();
        }
    }
}
