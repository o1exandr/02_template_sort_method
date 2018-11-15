/*
2.  Створити узагальнений метод, який отримує одновимірний масив та 
впорядковує його за зростанням(чи спаданням)  довільним алгоритмом впорядкування(бульбашкою чи ін.). 
Перевірити роботу методу для масивів цілого, рядкового типу,  масиву елементів користувацького типу(класу чи структури) 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_template_sort_method
{
    class Program
    {
        static void SortArr<T>(T[] arr) where T : IComparable
        {
            T tmp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) >= 1)
                    {
                        tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }

        static void PrintArr<T>(T[] arr, string message = "")
        {
            Console.WriteLine(message);
            foreach (var a in arr)
                Console.Write("{0}\t", a);
            Console.WriteLine();
        }

        public struct UserType //: IComparable
        {
            public string name;
            public int age;

            public UserType(string n, int a)
            {
                name = n;
                age = a;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 7, 5, 23 };
            PrintArr(arr, "\tInt before");
            SortArr(arr);
            PrintArr(arr, "\tInt after sorted");

            string[] str = { "zero", "one", "two", "three", "four" };
            PrintArr(str, "\n\tStr before");
            SortArr(str);
            PrintArr(str, "\tStr after sorted");


            Console.ReadKey();
        }
    }
}
