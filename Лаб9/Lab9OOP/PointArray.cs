using System;

namespace Lab9OOP
{
    internal class PointArray
    {
        private Point[] arr;
        public PointArray()
        {
            arr = new Point[0];
        }

        public PointArray(int size, int min, int max)
        {
            Random rand = new Random();
            arr = new Point[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Point(rand.Next(min, max), rand.Next(min, max));
            }
        }
        public PointArray(int size)
        {
            arr = new Point[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Точка {i + 1}:");
                double x = ReadDouble("  x = ");
                double y = ReadDouble("  y = ");
                arr[i] = new Point(x, y);
            }
        }
        public void Print()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{i}] ");
                arr[i].Print();
            }
        }

        public Point this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException($"Индекс {index} вне диапазона");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new ArgumentException($"Индекс {index} вне диапазона");
                arr[index] = value;
            }
        }
        public int Length
        {
            get { return arr.Length; }
        }

        static double ReadDouble(string prompt)
        {
            bool isInputValid;
            double value;
            do
            {
                Console.Write(prompt);
                isInputValid = double.TryParse(Console.ReadLine(), out value);
                if (!isInputValid)
                    Console.WriteLine("Некорректный ввод! Повторите.");
            } while (!isInputValid);
            return value;
        }
    }
}
