using System;

namespace Lab9OOP
{
    internal class Program
    {
        static Point FindNearestToOrigin(PointArray points)
        {
            if (points.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return null;
            }

            Point nearest = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].DistanceToOrigin() < nearest.DistanceToOrigin())
                    nearest = points[i];
            }
            return nearest;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1: класс Point");
            Point p1 = new Point(3, 4);
            Point p2 = new Point();
            p1.Print();
            p2.Print();
            Console.WriteLine(Point.DistanceToOrigin(p1));
            Console.WriteLine(p1.DistanceToOrigin());

            Console.WriteLine("\nЧасть 2: перегрузка операций");
            Point a = new Point(5, 8);
            Point b = new Point(1, 2);

            a--;
            a.Print();
            (-b).Print();

            int i = a;
            double d = (double)a;
            Console.WriteLine($"int: {i}, double: {d}");

            (a - 3).Print();
            (3 - a).Print();
            Console.WriteLine($"Расстояние a−b: {a - b}");

            Console.WriteLine("\nЧасть 3: коллекция PointArray");
            PointArray manual = new PointArray(2);
            manual.Print();

            PointArray randomArr = new PointArray(5, -10, 10);
            randomArr.Print();

            PointArray empty = new PointArray();
            empty.Print();

            Console.WriteLine("Ближайшая к центру:");
            FindNearestToOrigin(randomArr).Print();

            Console.WriteLine($"Всего создано точек: {Point.Count}");

            try
            {
                Point bad = randomArr[99];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
