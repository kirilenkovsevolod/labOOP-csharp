using System;
using System.Collections;
using ProductionLibrary;

namespace Lab10Demo
{
    public class SortByName : IComparer
    {
        public int Compare(object ob1, object ob2)
        {
            Production p1 = ob1 as Production;
            Production p2 = ob2 as Production;
            return string.Compare(p1.Name, p2.Name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");

            Production[] mas = new Production[8];
            mas[0] = new Production();
            mas[1] = new Factory();
            mas[2] = new Factory();
            mas[3] = new Workshop();
            mas[4] = new Workshop();
            mas[5] = new Workshop();
            mas[6] = new RepairShop();
            mas[7] = new RepairShop();

            foreach (Production p in mas)
                p.RandomInit();

            Console.WriteLine();
            Console.WriteLine("Виртуальный Show:");
            foreach (Production p in mas)
                p.Show();

            Console.WriteLine();
            Console.WriteLine("Невиртуальный ShowBaseInfo:");
            foreach (Production p in mas)
                p.ShowBaseInfo();

            Console.WriteLine();
            Console.WriteLine("Equals:");
            Production a = new Production("Заря", 100);
            Production b = new Production("Заря", 100);
            Console.WriteLine("a.Equals(b): " + a.Equals(b));
            Console.WriteLine("a == b: " + (a == b));

            Console.WriteLine("Часть 2. Запросы:");
            Console.WriteLine();

            int countWorkshops = 0;
            foreach (Production p in mas)
                if (p is Workshop) countWorkshops++;
            Console.WriteLine("Количество цехов: " + countWorkshops);

            int sumWorkers = 0;
            foreach (Production p in mas)
            {
                Factory f = p as Factory;
                if (f != null) sumWorkers += f.WorkerCount;
            }
            Console.WriteLine("Суммарное число рабочих фабрик и цехов: " + sumWorkers);

            Console.Write("Введите специализацию для поиска мастерских: ");
            string spec = Console.ReadLine();
            int countSpec = 0;
            foreach (Production p in mas)
                if (p is RepairShop r && r.Specialization == spec)
                {
                    r.Show();
                    countSpec++;
                }
            Console.WriteLine("Найдено мастерских: " + countSpec);

            Console.WriteLine("Часть 3:");
            Console.WriteLine();

            Console.WriteLine("Сортировка по числу рабочих (IComparable):");
            Array.Sort(mas);
            foreach (Production p in mas)
                p.Show();

            Console.WriteLine("Сортировка по названию (IComparer):");
            Array.Sort(mas, new SortByName());
            foreach (Production p in mas)
                p.Show();

            Console.Write("Введите название для бинарного поиска: ");
            string findName = Console.ReadLine();
            Array.Sort(mas, new SortByName());
            int pos = Array.BinarySearch(mas, new Production(findName, 0), new SortByName());
            if (pos >= 0)
                mas[pos].Show();
            else
                Console.WriteLine("Не найдено");

            Console.WriteLine("Массив IInit:");
            IInit[] initMas = new IInit[6];
            initMas[0] = new Factory();
            initMas[1] = new Workshop();
            initMas[2] = new RepairShop();
            initMas[3] = new RepairShop();
            initMas[4] = new Warehouse();
            initMas[5] = new Warehouse();

            foreach (IInit item in initMas)
                item.RandomInit();

            foreach (IInit item in initMas)
            {
                if (item is Production p) p.Show();
                if (item is Warehouse w) w.Show();
            }

            Console.WriteLine("Клонирование:");
            Workshop w1 = new Workshop("Прогресс", 50, "мебель", 3, "Иванов");
            Workshop wClone = (Workshop)w1.Clone();
            Workshop wCopy = w1.ShallowCopy();

            Console.WriteLine("оригинал: " + (Object.ReferenceEquals(w1, wCopy) ? "та же ссылка" : "другая ссылка"));
            Console.WriteLine("Equals клона и оригинала: " + w1.Equals(wClone));
            wClone.Master = "Петров";
            wCopy.Master = "Сидоров";
            w1.Show();
            wClone.Show();
            wCopy.Show();
        }
    }
}
