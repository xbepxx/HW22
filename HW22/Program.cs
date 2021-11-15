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
        static int[] Mass()
        {
            //int a;
            Random random = new Random();
            Console.WriteLine("Введите размер массива:");
            int a = int.Parse(Console.ReadLine());
            int[] mas = new int[a];
            for (int i = 0; i < a; i++)
            {
                mas[i] = random.Next(0, 100);
            }
            return mas;
        }
        static void Sum(Task task, object _array)
        {
            int[] p = (int[])_array;
            int sum = 0;
            foreach (int n in p)
            {
                sum = sum + n;
            }
            Console.WriteLine($"Сумма чисел в массиве равна {sum}");
        }
        static void Max(Task task, object _array)
        {
            int[] p = (int[])_array;
            int max = p.Max();
            Console.WriteLine($"Максимальное значение в массиве: {max}");
        }
        static void Main(string[] args)
        {
            Func<int[]> func = new Func<int[]>(Mass);
            Task<int[]> task1 = new Task<int[]>(func);
            task1.Start();
            int[] array = task1.Result;

            Action<Task, object> action1 = new Action<Task, object>(Sum);
            Task task2 = task1.ContinueWith(action1, array);

            Action<Task, object> action2 = new Action<Task, object>(Max);
            Task task3 = task2.ContinueWith(action2, array);
            Console.ReadKey();
        }
    }
}
