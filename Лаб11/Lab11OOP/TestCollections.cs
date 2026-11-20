using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab11OOP
{
    public class TestCollections
    {
        Queue<Workshop> col1;
        Queue<string> col1s;
        Dictionary<Production, Workshop> col2;
        Dictionary<string, Workshop> col2s;

        public TestCollections(int n)
        {
            col1 = new Queue<Workshop>();
            col1s = new Queue<string>();
            col2 = new Dictionary<Production, Workshop>();
            col2s = new Dictionary<string, Workshop>();

            string[] names = { "Альфа", "Восход", "Прогресс", "Заря", "Маяк", "Сокол" };
            string[] products = { "мебель", "ткани", "станки", "игрушки" };
            string[] masters = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };

            for (int i = 0; i < n; i++)
            {
                Workshop w = new Workshop(names[i % names.Length] + i, 10 + i,
                    products[i % products.Length], 1 + i % 20, masters[i % masters.Length]);
                string s = w.ToString();

                col1.Enqueue(w);
                col1s.Enqueue(s);
                col2.Add(w.BaseProduction, w);
                col2s.Add(s, w);
            }
        }

        static Workshop CopyOf(Workshop w)
        {
            return new Workshop(w.Name, w.WorkerCount, w.ProductProfile, w.WorkshopNumber, w.Master);
        }

        static long Ticks(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedTicks;
        }

        void PrintRow(string label, Workshop w, string s, Production key)
        {
            long t1 = Ticks(() => col1.Contains(w));
            long t2 = Ticks(() => col1s.Contains(s));
            long t3 = Ticks(() => col2.ContainsKey(key));
            long t4 = Ticks(() => col2.ContainsValue(w));
            long t5 = Ticks(() => col2s.ContainsKey(s));
            Console.WriteLine(label + ": " + t1 + " | " + t2 + " | " + t3 + " | " + t4 + " | " + t5);
        }

        public void MeasureSearch()
        {
            Console.WriteLine("Поиск, тиков: Queue<Workshop> | Queue<string> | Dict ContainsKey | Dict ContainsValue | Dict<string> ContainsKey");

            Workshop[] all = col1.ToArray();

            Workshop first = CopyOf(all[0]);
            Workshop middle = CopyOf(all[all.Length / 2]);
            Workshop last = CopyOf(all[all.Length - 1]);
            Workshop none = new Workshop("Нет такого", 0, "нет", 1, "нет");

            PrintRow("первый   ", first, first.ToString(), first.BaseProduction);
            PrintRow("средний  ", middle, middle.ToString(), middle.BaseProduction);
            PrintRow("последний", last, last.ToString(), last.BaseProduction);
            PrintRow("нет      ", none, none.ToString(), none.BaseProduction);
        }
    }
}
