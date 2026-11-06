using System;

namespace Lab9OOP
{
    internal class Point
    {
        private double x;
        private double y;
        private static int count = 0;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public static int Count
        {
            get { return count; }
        }
        public Point() : this(0, 0) { }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
            count++;
        }
        public void Print()
        {
            Console.WriteLine($"({x}, {y})");
        }
        public static double DistanceToOrigin(Point p)
        {
            return Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }
        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public static Point operator --(Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        }
        public static Point operator -(Point p)
        {
            return new Point(p.Y, p.X);
        }
        public static implicit operator int(Point p)
        {
            return (int)p.X;
        }
        public static explicit operator double(Point p)
        {
            return (double)p.Y;
        }
        public static Point operator -(Point p, int d)
        {
            return new Point(p.X - d, p.Y);
        }
        public static Point operator -(int d, Point p)
        {
            return new Point(p.X, p.Y - d);
        }
        public static double operator -(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}
