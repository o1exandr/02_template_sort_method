/*
2.  Створити узагальнений метод, який отримує одновимірний масив та 
впорядковує його за зростанням(чи спаданням)  довільним алгоритмом впорядкування(бульбашкою чи ін.). 
Перевірити роботу методу для масивів цілого, рядкового типу,  масиву елементів користувацького типу(класу чи структури) 
 */

using System;


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
                Console.Write("\t{0}", a);
            Console.WriteLine();
        }

        public struct UserType : IComparable
        {
            public string name;
            public int age;

            public UserType(string n, int a)
            {
                name = n;
                age = a;
            }

            public override string ToString()
            {
                return $"Name:\t{name}\tAge:\t{age}\n";
            }

            public int CompareTo(object obj)
            {
                UserType user = (UserType)obj;
                return this.name.CompareTo(user.name);
            }
        }

            static void Main(string[] args)
        {
            int[] arr = { 10, 20, 7, 5, 23 };
            PrintArr(arr, "\nInt before");
            SortArr(arr);
            PrintArr(arr, "\nInt after sorted");

            string[] str = { "zero", "one", "two", "three", "four" };
            PrintArr(str, "\nStr before");
            SortArr(str);
            PrintArr(str, "\nStr after sorted");

            UserType[] ut = 
            {
                new UserType("Ted", 32),
                new UserType("Will", 17),
                new UserType("Ann", 25)
            };

            PrintArr(ut, "\nStruct before");
            SortArr(ut);
            PrintArr(ut, "\nStruct after sorted (by name)");

            Console.ReadKey();
        }
    }
}
