using System;

class Program
{
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

    static void PrintPointResult(double x1, double y1, bool isPointInside)
    {
        Console.WriteLine("Точка ({0}; {1}) принадлежит области: {2}", x1, y1, isPointInside);
    }

    static void Main(string[] args)
    {
        double x1 = ReadDouble("Введите координату x: ");
        double y1 = ReadDouble("Введите координату y: ");
        bool isPointInside = (y1 >= 0) && (y1 <= x1 + 2) && (y1 <= 2 - x1);
        PrintPointResult(x1, y1, isPointInside);
    }
}
