using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11OOP
{
    internal class Program
    {
        static Production MakeRandomItem()
        {
            Random rnd = new Random();
            int kind = rnd.Next(4);
            if (kind == 0)
            {
                Production p = new Production();
                p.RandomInit();
                return p;
            }
            if (kind == 1)
            {
                Factory f = new Factory();
                f.RandomInit();
                return f;
            }
            if (kind == 2)
            {
                Workshop w = new Workshop();
                w.RandomInit();
                return w;
            }
            RepairShop r = new RepairShop();
            r.RandomInit();
            return r;
        }

        static void PrintQueryResults(IEnumerable collection)
        {
            int countWorkshops = 0;
            foreach (object obj in collection)
                if (obj is Workshop) countWorkshops++;
            Console.WriteLine("Количество цехов: " + countWorkshops);

            int sumWorkers = 0;
            foreach (object obj in collection)
            {
                Production p = obj as Production;
                if (p != null) sumWorkers += p.WorkerCount;
            }
            Console.WriteLine("Суммарное число рабочих: " + sumWorkers);

            Console.WriteLine("Мастерские:");
            foreach (object obj in collection)
                if (obj is RepairShop r) r.Show();
        }

        static void PrintQueryResultsGeneric(IEnumerable<Production> collection)
        {
            int countWorkshops = 0;
            foreach (Production p in collection)
                if (p is Workshop) countWorkshops++;
            Console.WriteLine("Количество цехов: " + countWorkshops);

            int sumWorkers = 0;
            foreach (Production p in collection)
                sumWorkers += p.WorkerCount;
            Console.WriteLine("Суммарное число рабочих: " + sumWorkers);

            Console.WriteLine("Мастерские:");
            foreach (Production p in collection)
                if (p is RepairShop r) r.Show();
        }

        static void Task1()
        {
            Queue collection = new Queue();
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Задание 1. Queue (System.Collections)");
                Console.WriteLine("1. Добавить объект (случайный)");
                Console.WriteLine("2. Удалить объект из начала очереди");
                Console.WriteLine("3. Печать (foreach)");
                Console.WriteLine("4. Запросы");
                Console.WriteLine("5. Клонирование");
                Console.WriteLine("6. Сортировка и поиск");
                Console.WriteLine("7. Назад");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Production item = MakeRandomItem();
                    collection.Enqueue(item);
                    item.Show();
                }
                else if (choice == 2)
                {
                    if (collection.Count == 0)
                        Console.WriteLine("Очередь пуста");
                    else
                    {
                        Production removed = (Production)collection.Dequeue();
                        Console.WriteLine("Удален:");
                        removed.Show();
                    }
                }
                else if (choice == 3)
                {
                    if (collection.Count == 0)
                        Console.WriteLine("Очередь пуста");
                    else
                        foreach (object obj in collection)
                            ((Production)obj).Show();
                }
                else if (choice == 4)
                {
                    PrintQueryResults(collection);
                }
                else if (choice == 5)
                {
                    Queue clone = new Queue(collection);
                    Console.WriteLine("Клон (" + clone.Count + " элементов):");
                    foreach (object obj in clone)
                        ((Production)obj).Show();
                }
                else if (choice == 6)
                {
                    object[] arr = collection.ToArray();
                    Array.Sort(arr);
                    collection = new Queue(arr);
                    Console.WriteLine("После сортировки по числу рабочих:");
                    foreach (object obj in collection)
                        ((Production)obj).Show();

                    Production find = new Production("Заря", 100);
                    Console.WriteLine("Поиск " + "Производство \"Заря\", 100 рабочих" + ": " + collection.Contains(find));
                }
            } while (choice != 7);
        }

        static void Task2()
        {
            Stack<Production> collection = new Stack<Production>();
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Задание 2. Stack<Production> (System.Collections.Generic)");
                Console.WriteLine("1. Добавить объект (случайный)");
                Console.WriteLine("2. Удалить объект с вершины стека");
                Console.WriteLine("3. Печать (foreach)");
                Console.WriteLine("4. Запросы");
                Console.WriteLine("5. Клонирование");
                Console.WriteLine("6. Сортировка и поиск");
                Console.WriteLine("7. Назад");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Production item = MakeRandomItem();
                    collection.Push(item);
                    item.Show();
                }
                else if (choice == 2)
                {
                    if (collection.Count == 0)
                        Console.WriteLine("Стек пуст");
                    else
                    {
                        Production removed = collection.Pop();
                        Console.WriteLine("Удален:");
                        removed.Show();
                    }
                }
                else if (choice == 3)
                {
                    if (collection.Count == 0)
                        Console.WriteLine("Стек пуст");
                    else
                        foreach (Production p in collection)
                            p.Show();
                }
                else if (choice == 4)
                {
                    PrintQueryResultsGeneric(collection);
                }
                else if (choice == 5)
                {
                    Stack<Production> clone = new Stack<Production>(collection);
                    Console.WriteLine("Клон (" + clone.Count + " элементов):");
                    foreach (Production p in clone)
                        p.Show();
                }
                else if (choice == 6)
                {
                    Production[] arr = collection.ToArray();
                    Array.Sort(arr);
                    collection = new Stack<Production>(arr);
                    Console.WriteLine("После сортировки по числу рабочих:");
                    foreach (Production p in collection)
                        p.Show();

                    Production find = new Production("Заря", 100);
                    Console.WriteLine("Поиск \"Заря\", 100: " + collection.Contains(find));
                }
            } while (choice != 7);
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Лабораторная работа 11. Коллекции");
                Console.WriteLine("1. Задание 1. Queue");
                Console.WriteLine("2. Задание 2. Stack<T>");
                Console.WriteLine("3. Задание 3. TestCollections");
                Console.WriteLine("4. Выход");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1) Task1();
                else if (choice == 2) Task2();
                else if (choice == 3)
                {
                    TestCollections ts = new TestCollections(1000);
                    ts.MeasureSearch();
                }
            } while (choice != 4);
        }
    }
}
