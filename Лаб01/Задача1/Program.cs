using System;

class Program
{
    // Запрашивает целое число
    static int ReadInt(string prompt)
    {
        bool isInputValid;
        int value;
        do
        {
            Console.Write(prompt);
            isInputValid = int.TryParse(Console.ReadLine(), out value);
            if (!isInputValid)
                Console.WriteLine("Некорректный ввод! Повторите.");
        } while (!isInputValid);
        return value;
    }

    // Запрашивает вещественное число
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

    // Вывод 
    static void PrintExpression(string name, int result, int m, int n)
    {
        Console.WriteLine("{0} ={1}, m={2},n={3}", name, result, m, n);
    }

    // Вывод bool
    static void PrintBoolExpression(string name, bool result, int m, int n)
    {
        Console.WriteLine("{0} ={1}, m={2},n={3}", name, result, m, n);
    }

    static void Main(string[] args)
    {
        int m = ReadInt("Введите целое число m: ");
        int n = ReadInt("Введите целое число n: ");
        double x = ReadDouble("Введите x:");


        Console.WriteLine("1-ое задание(m++/n--):");
        int divisionM = m, divisionN = n;
        if (divisionN == 0)
            Console.WriteLine("Нельзя вычислить(деление на 0)");
        else
        {
            int divisionResult = divisionM++ / divisionN--;
            PrintExpression("m++/n--", divisionResult, divisionM, divisionN);
        }

        Console.WriteLine("\n2-ое задание(++m < n--)");
        int comparisonM = m, comparisonN = n;                             
        bool isMLess = ++comparisonM < comparisonN--;    
        PrintBoolExpression("++m < n--", isMLess, comparisonM, comparisonN);

        Console.WriteLine("\n3-е задание(n-- > m)");
        int greaterM = m, greaterN = n;
        bool isNGreater = greaterN-- > greaterM;       
        PrintBoolExpression("n-- > m", isNGreater, greaterM, greaterN);

        Console.WriteLine("\n4-ое задание(sin(x^3) + x^4 + корень 5-й степени(x^2 + x^3))");
        double radicand = x * x + x * x * x;         
        if (radicand < 0)
            Console.WriteLine("Нельзя вычислить(x^2 + x^3 = {0} < 0)", radicand);
        else
        {
            double functionResult = Math.Sin(Math.Pow(x, 3)) + Math.Pow(x, 4) + Math.Pow(radicand, 1.0 / 5);
            Console.WriteLine("sin(x^3) + x^4 + корень 5-й степени(x^2 + x^3) = {0}", functionResult);
        }
    }
}
